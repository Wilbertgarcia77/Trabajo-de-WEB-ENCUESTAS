-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-09-2025 a las 05:22:59
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `encuestasgymdb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recomendaciones`
--

CREATE TABLE `recomendaciones` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `tipo_encuesta` varchar(100) NOT NULL,
  `recomendacion_texto` text NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `recomendaciones`
--

INSERT INTO `recomendaciones` (`id`, `usuario_id`, `tipo_encuesta`, `recomendacion_texto`, `fecha`) VALUES
(1, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:13:21'),
(2, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:15:09'),
(3, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:17:50'),
(4, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:21:21'),
(5, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:23:09'),
(6, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:23:15'),
(7, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"You didn\'t provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you\'re accessing the API from your browser and are prompted for a username and password. You can obtain an API key from https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": null\n    }\n}\n', '2025-08-31 20:23:26'),
(8, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"Incorrect API key provided: sk-svcac***********************************************************************************************************************************************************5wEA. You can find your API key at https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": \"invalid_api_key\"\n    }\n}\n', '2025-08-31 20:23:50'),
(9, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"Incorrect API key provided: sk-svcac***********************************************************************************************************************************************************5wEA. You can find your API key at https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": \"invalid_api_key\"\n    }\n}\n', '2025-08-31 20:34:29'),
(10, 1, 'Personales', 'No se pudo obtener una recomendación de OpenAI. Error: The given key was not present in the dictionary.\nRespuesta JSON: {\n    \"error\": {\n        \"message\": \"Incorrect API key provided: sk-svcac***********************************************************************************************************************************************************5wEA. You can find your API key at https://platform.openai.com/account/api-keys.\",\n        \"type\": \"invalid_request_error\",\n        \"param\": null,\n        \"code\": \"invalid_api_key\"\n    }\n}\n', '2025-08-31 20:34:43'),
(11, 1, 'Personales', 'Basado en las respuestas proporcionadas, aquí tienes algunas recomendaciones personalizadas para el usuario:\n\n### Entrenamiento Físico:\n\n1. **Frecuencia de Entrenamiento:** Dado que el usuario tiene una ocupación sedentaria como ingeniero en sistemas, recomiendo al menos 3-4 días de entrenamiento a la semana para compensar la falta de actividad física durante el día laboral.\n\n2. **Combinación de Ejercicios:** \n   - **Cardio:** Incluya 2-3 sesiones de ejercicios cardiovasculares de intensidad moderada (como correr, nadar o ciclismo) para mejorar la salud cardiovascular.\n   - **Fuerza:** Realice entrenamiento de fuerza 2-3 veces por semana. Esto puede incluir entrenamiento con pesas, TRX, o calistenia para mejorar la masa muscular y la fuerza general.\n   - **Flexibilidad y Movilidad:** Incorpore sesiones de estiramientos o yoga al menos una vez por semana para mejorar la flexibilidad y reducir el estrés.\n\n3. **Descanso y Recuperación:** Dado que el usuario menciona que duerme solo 5 horas por noche, es crucial priorizar el sueño. Intente aumentar las horas de sueño a 7-9 por noche para una mejor recuperación y desempeño físico.\n\n### Nutrición:\n\n1. **Planificación de Comidas:** Dado que queda claro que el usuario tiene hábitos que podrían no ser los más saludables, sugiero planificar comidas con anticipación para asegurarse de que sean equilibradas y nutritivas.\n\n2. **Macronutrientes:**\n   - **Proteínas:** Aumentar el consumo de proteínas magras (como pollo, pescado, tofu, legumbres) para ayudar en la recuperación muscular.\n   - **Carbohidratos Complejos:** Incorpore carbohidratos complejos (como arroz integral, avena, quinoa) para energía sostenida durante el día.\n   - **Grasas Saludables:** Incluya grasas saludables (como aguacate, nueces, aceite de oliva) para una dieta balanceada.\n\n3. **Hidratación:** Mantenga una buena ingesta de agua a lo largo del día. Recomendado al menos 2-3 litros, ajustando según la intensidad de los entrenamientos.\n\n### Estilo de Vida y Bienestar:\n\n1. **Gestión del Estrés:** Considera técnicas de relajación como la meditación, respiración profunda o el yoga para reducir el estrés laboral.\n\n2. **Tiempo al Aire Libre:** Intente pasar más tiempo al aire libre durante los fines de semana o después del trabajo para recibir luz natural y mejorar el estado de ánimo.\n\n3. **Consulta Profesional:** Aunque el usuario no tiene enfermedades crónicas, es importante realizar chequeos médicos regulares si presenta algún tipo de malestar o si el médico así lo ha recomendado, ya que optimizar la salud general es esencial para alcanzar los objetivos físicos y de bienestar.\n\nRecuerda que las recomendaciones son generales y siempre es recomendable ajustar cualquier plan según las necesidades y circunstancias individuales del usuario.', '2025-08-31 20:36:48'),
(12, 1, 'Personales', 'Para un usuario de 20 años que trabaja como ingeniero en sistemas, se dedica a hábitos tanto positivos como negativos (suponiendo que se refiere a ejercicio y posiblemente malos hábitos alimenticios o sedentarismo), duerme alrededor de 5 horas y no tiene enfermedades crónicas, podemos crear algunas recomendaciones personalizadas enfocadas en mejorar su estilo de vida general. \n\n1. **Sueño:**\n   - El sueño es crucial para la recuperación y el bienestar general. Intenta ajustar tu rutina para dormir al menos 7-8 horas por noche. Mejora la calidad de tu sueño asegurándote un ambiente oscuro y tranquilo, evitando pantallas al menos 30 minutos antes de dormir.\n\n2. **Nutrición:**\n   - **Desayuno:** Consume un desayuno balanceado con carbohidratos complejos (avena, pan integral), proteínas (huevos, yogur griego) y grasas saludables (aguacate, nueces).\n   - **Comidas regulares:** Intenta mantener una dieta balanceada incorporando una variedad de alimentos: muchas verduras, proteínas magras (pollo, pescado, legumbres) y grasas saludables.\n   - **Snacks saludables:** Opta por frutas, yogur o frutos secos en lugar de opciones procesadas.\n   - Si tienes malos hábitos alimenticios, trabaja en reducir el consumo de alimentos ultraprocesados y azúcares añadidos.\n\n3. **Actividad Física:**\n   - **Cardio:** Intenta realizar ejercicios cardiovasculares al menos 150 minutos por semana (caminar, correr, andar en bicicleta).\n   - **Entrenamiento de Fuerza:** Incluye sesiones de entrenamiento de fuerza al menos 2-3 veces por semana para mejorar la masa muscular y el metabolismo (usa pesas o el peso corporal).\n   - **Flexibilidad y Movilidad:** Agrega estiramientos o yoga para mejorar la flexibilidad y reducir el estrés.\n\n4. **Gestión del Estrés:**\n   - Debido a las largas horas de trabajo típicas en sistemas, y la falta de sueño, puedes beneficiarte de técnicas de manejo del estrés como la meditación, la respiración profunda o el yoga.\n\n5. **Productividad y Bienestar:**\n   - Organiza tus tareas para evitar el estrés y el trabajo desorganizado. El uso de una lista de tareas pendientes y la técnica Pomodoro pueden ayudarte a mejorar tu productividad y encontrar tiempo para ejercicios y descanso.\n\n6. **Consulta médica:**\n   - Ya que el médico ha recomendado la práctica de ejercicio, asegúrate de seguir sus consejos específicos y consulta periódicamente para monitorear tu progreso y ajustar tu plan de ejercicios o dieta según sea necesario.\n\nEs importante ajustar estas recomendaciones según sientas la evolución de tu cuerpo y bienestar, ya que cada persona responde de manera diferente.', '2025-08-31 20:39:45'),
(13, 1, 'Personales', 'Dado el perfil del usuario de 45 años con diabetes, que trabaja como albañil y presenta hábitos como el consumo de alcohol y tabaco, es importante tener en cuenta varios aspectos para mejorar su salud y bienestar:\n\n**1. Evaluación médica:**\n   - Asegúrate de que el usuario ha tenido una consulta médica reciente para evaluar su diabetes y cualquier otra condición de salud. Es esencial que siga las recomendaciones de su médico, especialmente relacionadas con la diabetes.\n\n**2. Plan de alimentación:**\n   - **Alimentación balanceada:** Establece un plan de comidas que sea bajo en azúcares simples y carbohidratos refinados para ayudar a controlar los niveles de glucosa. Enfatiza la ingesta de proteínas magras, granos integrales, grasas saludables (como aguacate o aceite de oliva), verduras y frutas en porciones controladas.\n   - **Porciones controladas:** Enseña sobre el control de porciones para evitar picos de glucosa y garantizar un buen manejo del peso.\n   - **Hidratación adecuada:** Promueve la ingesta de suficiente agua al día. Limita el consumo de bebidas alcohólicas; sugiere la moderación y establecer límites si no es posible eliminarlas completamente.\n\n**3. Ejercicio físico:**\n   - **Entrenamiento cardiovascular:** Introduce ejercicios cardiovasculares de bajo impacto, como caminar, nadar o andar en bicicleta. Intenta que estos sean parte de su rutina diaria, al menos 30 minutos al día, cinco veces por semana.\n   - **Fortalecimiento muscular:** Implementa ejercicios de fortalecimiento para prevenir lesiones en su ocupación como albañil y mejorar el control de la glucosa. Incluye ejercicios de resistencia con bandas elásticas o pesas ligeras.\n   - **Flexibilidad y equilibrio:** Incorpora estiramientos o prácticas como yoga o tai chi para mejorar la flexibilidad y el equilibrio.\n\n**4. Modificación de hábitos:**\n   - **Reducción del tabaco y alcohol:** Proporciona recursos o apoyo para reducir la dependencia del tabaco y el consumo excesivo de alcohol, ambos factores que complican el manejo de la diabetes.\n   - **Técnicas de manejo del estrés:** Recomiéndale técnicas de relajación como la meditación, respiración profunda o actividades de ocio.\n\n**5. Sueño y descanso:**\n   - Aunque duerma 10 horas, hay que verificar la calidad del sueño. Asegúrate de que tenga un ambiente propicio para el descanso y hábitos de sueño saludables.\n   - Asegúrate de que estas horas no afecten su nivel de actividad durante el día.\n\n**6. Monitorización y ajustes:**\n   - Aconseja sobre la importancia de seguir vigilando sus niveles de glucosa regularmente y ajustando el plan de alimentación y ejercicio según sea necesario y bajo supervisión médica.\n\nEstas recomendaciones deben adaptarse a su progreso y revaluar periódicamente según su evolución de salud y bienestar. Siempre es fundamental trabajar en colaboración con su médico, especialmente para ajustes relacionados con la diabetes.', '2025-08-31 20:42:07');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reportes`
--

CREATE TABLE `reportes` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `tipo_encuesta` varchar(50) NOT NULL,
  `datos` text NOT NULL,
  `fecha` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `reportes`
--

INSERT INTO `reportes` (`id`, `usuario_id`, `tipo_encuesta`, `datos`, `fecha`) VALUES
(3, 1, 'Personales', '{\'edad\':45,\'enfermedadCronica\':\'si tengo diabetes\',\'recomendadoMedico\':\'claro\',\'ocupacion\':\'albañil\',\'horasSueno\':10,\'habitos\':\'bebo alcohol y fumo\'}', '2025-08-31 20:41:40');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuestas_ejercicio`
--

CREATE TABLE `respuestas_ejercicio` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) DEFAULT NULL,
  `dias_ejercicio` int(11) DEFAULT NULL,
  `tipo_ejercicio` varchar(255) DEFAULT NULL,
  `condicion_fisica` varchar(255) DEFAULT NULL,
  `fecha` datetime DEFAULT current_timestamp(),
  `objetivo` varchar(255) DEFAULT NULL,
  `tiempo_sesion` int(11) DEFAULT NULL,
  `preferencia_grupo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuestas_nutricion`
--

CREATE TABLE `respuestas_nutricion` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) DEFAULT NULL,
  `plan_alimenticio` varchar(255) DEFAULT NULL,
  `restriccion_alimentaria` varchar(255) DEFAULT NULL,
  `comidas_por_dia` int(11) DEFAULT NULL,
  `fecha` datetime DEFAULT current_timestamp(),
  `suplementos` varchar(255) DEFAULT NULL,
  `agua_dia` double DEFAULT NULL,
  `alergias` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuestas_personales`
--

CREATE TABLE `respuestas_personales` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) DEFAULT NULL,
  `edad` int(11) DEFAULT NULL,
  `enfermedad_cronica` varchar(255) DEFAULT NULL,
  `recomendado_medico` varchar(255) DEFAULT NULL,
  `fecha` datetime DEFAULT current_timestamp(),
  `ocupacion` varchar(255) DEFAULT NULL,
  `horas_sueno` int(11) DEFAULT NULL,
  `habitos` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `respuestas_personales`
--

INSERT INTO `respuestas_personales` (`id`, `usuario_id`, `edad`, `enfermedad_cronica`, `recomendado_medico`, `fecha`, `ocupacion`, `horas_sueno`, `habitos`) VALUES
(2, 1, 20, 'no', 'sii', '2025-08-31 20:13:09', 'ingeniero en sistema', 5, 'si las dos'),
(3, 1, 25, 'no', 'sii', '2025-08-31 20:14:57', 'ingeniero en sistema', 5, 'si las dos'),
(4, 1, 45, 'si tengo diabetes', 'claro', '2025-08-31 20:41:40', 'albañil', 10, 'bebo alcohol y fumo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `nombre`, `email`, `password`) VALUES
(1, 'wilbert', 'elisbetgarcia053@gmail.com', '123qwe');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `recomendaciones`
--
ALTER TABLE `recomendaciones`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `reportes`
--
ALTER TABLE `reportes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `respuestas_ejercicio`
--
ALTER TABLE `respuestas_ejercicio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `respuestas_nutricion`
--
ALTER TABLE `respuestas_nutricion`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `respuestas_personales`
--
ALTER TABLE `respuestas_personales`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `recomendaciones`
--
ALTER TABLE `recomendaciones`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `reportes`
--
ALTER TABLE `reportes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `respuestas_ejercicio`
--
ALTER TABLE `respuestas_ejercicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `respuestas_nutricion`
--
ALTER TABLE `respuestas_nutricion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `respuestas_personales`
--
ALTER TABLE `respuestas_personales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `recomendaciones`
--
ALTER TABLE `recomendaciones`
  ADD CONSTRAINT `recomendaciones_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);

--
-- Filtros para la tabla `reportes`
--
ALTER TABLE `reportes`
  ADD CONSTRAINT `reportes_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);

--
-- Filtros para la tabla `respuestas_ejercicio`
--
ALTER TABLE `respuestas_ejercicio`
  ADD CONSTRAINT `respuestas_ejercicio_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);

--
-- Filtros para la tabla `respuestas_nutricion`
--
ALTER TABLE `respuestas_nutricion`
  ADD CONSTRAINT `respuestas_nutricion_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);

--
-- Filtros para la tabla `respuestas_personales`
--
ALTER TABLE `respuestas_personales`
  ADD CONSTRAINT `respuestas_personales_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
