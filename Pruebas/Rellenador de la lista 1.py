import random
import string
import mysql.connector
import datetime

def generar_nombre_completo(nombres, apellidos, nombres_completos_generados):
    while True:
        nombre = random.choice(nombres)
        apellido = random.choice(apellidos)
        nombre_completo = f'{nombre} {apellido}'
        if nombre_completo not in nombres_completos_generados:
            nombres_completos_generados.add(nombre_completo)
            return nombre_completo


def generar_fechas_aleatorias():
    fechas = []
    today = datetime.date.today()
    for _ in range(14):
        random_date = today - datetime.timedelta(days=random.randint(1, 365))
        fechas.append(random_date.strftime('%d/%m/%Y'))
    return fechas



def generar_datos_aleatorios():
    nombres = ['Juan', 'María', 'Carlos', 'Ana', 'Luis', 'Laura', 'José', 'Margarita', 'Pedro', 'Sofía', 'Diego', 'Valentina', 'Andrés', 'Fernanda', 'Javier', 'Camila', 'Ricardo', 'Isabella', 'Roberto', 'Paula', 'Manuel', 'Gabriela', 'Miguel', 'Daniela', 'Francisco', 'Jimena', 'Alejandro', 'Renata', 'Sebastián', 'Lucía', 'Antonio', 'Carolina', 'Rodrigo', 'Natalia', 'Emilio', 'Marcela', 'Arturo', 'Julia', 'Gonzalo', 'Victoria', 'Óscar', 'Claudia', 'Rafael', 'Silvia', 'Jorge', 'Catalina', 'Hugo', 'Patricia', 'Guillermo', 'Elena', 'Adrián', 'Adriana', 'Enrique', 'Mónica', 'Eduardo', 'Lorena', 'Raúl', 'Carmen', 'Mario', 'Pamela', 'Federico', 'Rosario', 'Sergio', 'Olivia', 'Daniel', 'Marina', 'Alejandrro', 'Estefanía', 'Ernesto', 'Laura', 'Víctor', 'Ángela', 'Julio', 'Susana', 'Lorenzo', 'Alicia', 'Alberto', 'Marisol', 'René', 'Celeste', 'Óliver', 'Tania', 'Jaime', 'Karen', 'Leonardo', 'Vanessa', 'Salvador', 'Brenda', 'Mauricio', 'Diana', 'Tomás', 'Gabriela', 'Ignacio', 'Verónica', 'Marcos', 'Paola', 'Ulises', 'Rosa']
    apellidos = ['Gómez', 'Rodríguez', 'López', 'Pérez', 'Martínez', 'Hernández', 'García', 'González', 'Mendoza', 'Torres', 'Sánchez', 'Ramírez', 'Flores', 'Morales', 'Ortega', 'Vargas', 'Cruz', 'Ramos', 'Castillo', 'Castro', 'Rojas', 'Reyes', 'Romero', 'Fernández', 'Chávez', 'Álvarez', 'Silva', 'Juárez', 'Herrera', 'Medina', 'Guerrero', 'Vega', 'Campos', 'Luna', 'Jiménez', 'Valenzuela', 'Navarro', 'Cortés', 'Cabrera', 'Ríos', 'Delgado', 'Montes', 'Orozco', 'Guzmán', 'Miranda', 'Bautista', 'Vázquez', 'Soto', 'Villanueva', 'Salgado', 'Méndez', 'Aguilar', 'Carrillo', 'Escobar', 'Paredes', 'Molina', 'León', 'Cervantes', 'Moreno', 'Cano', 'Rangel', 'Rivera', 'Zamora', 'Valdés', 'Serrano', 'Solís', 'Castañeda', 'Acosta', 'Andrade', 'Gallardo', 'Peralta', 'Esparza', 'Miramontes', 'Nava', 'Olivares', 'Villa', 'Fuentes', 'Cordero', 'Barrera', 'Balderas', 'Lara', 'Olvera', 'Velázquez', 'Palacios', 'Chávez', 'Cárdenas', 'Beltrán', 'Cuevas', 'Roldán', 'Salinas', 'Laguna', 'Trejo', 'Hidalgo', 'Esquivel', 'Zúñiga', 'Ávalos']
    nombres_completos_generados = set()
    promotor = ['Promotor1', 'Promotor2', 'Promotor3']
    tipo_de_interes = ['Preferencial', 'Premier', 'Normal']
    tipo_de_pago = ['Semanal', 'Quincenal']
    registros = []

    while len(registros) < 2000:
        Promotor = random.choice(promotor)
        nombre_completo = generar_nombre_completo(nombres, apellidos, nombres_completos_generados)
        credito_prestado = ''.join(random.choices(string.digits, k=5))
        pagare = str(int(credito_prestado) * 2)
        fecha_inicio = '' + datetime.date(random.randint(1900, 2023), random.randint(1, 12), random.randint(1, 28)).strftime('%d/%m/%Y')
        fecha_termino = '' + datetime.date(random.randint(1900, 2023), random.randint(1, 12), random.randint(1, 28)).strftime('%d/%m/%Y')
        interes = random.choice(tipo_de_interes)
        monto_total = str(random.randint(1000, 5000))
        calle = ''.join(random.choices(string.ascii_uppercase + string.ascii_lowercase + string.digits, k=10))
        colonia = ''.join(random.choices(string.ascii_uppercase + string.ascii_lowercase + string.digits, k=10))
        num_int = str(random.randint(1, 100))
        num_ext = str(random.randint(1, 1000))
        telefono = ''.join(random.choices(string.digits, k=12))
        correo = ''.join(random.choices(string.ascii_lowercase + string.digits, k=12)) + '@Gmail.com'
        tipo_pago = random.choice(tipo_de_pago)
        monto_restante = str(random.randint(0, int(monto_total)))
        fechas = generar_fechas_aleatorias()
        registro = (
            Promotor, nombre_completo, credito_prestado, pagare, fecha_inicio, fecha_termino, interes, monto_total,
            calle, colonia, num_int, num_ext, telefono, correo, tipo_pago, monto_restante
        ) + tuple(fechas)
        registros.append(registro)

    return registros

# Conexión a la base de datos MySQL
conexion = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database="prestamos"
)

# Obtener los registros generados
registros = generar_datos_aleatorios()

# Insertar los registros en lotes de 100
cursor = conexion.cursor()
batch_size = 100
for i in range(0, len(registros), batch_size):
    batch = registros[i:i+batch_size]
    batch_list = [tuple(record) for record in batch]  # Convert batch to a list of tuples

    cursor.executemany("""
        INSERT INTO lista1 (
            Promotor, Nombre_Completo, Credito_Prestado, Pagare, Fecha_Inicio, Fecha_Termino, Interes, Monto_Total,
            Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante,
            Fecha1, Fecha2, Fecha3, Fecha4, Fecha5, Fecha6, Fecha7, Fecha8, Fecha9, Fecha10,
            Fecha11, Fecha12, Fecha13, Fecha14
        ) VALUES (
            %s, %s, %s, %s, %s, %s, %s, %s,
            %s, %s, %s, %s, %s, %s, %s, %s,
            %s, %s, %s, %s, %s, %s, %s, %s, %s, %s,
            %s, %s, %s, %s
        )
    """, batch_list)
    conexion.commit()

# Cerrar la conexión
cursor.close()
conexion.close()