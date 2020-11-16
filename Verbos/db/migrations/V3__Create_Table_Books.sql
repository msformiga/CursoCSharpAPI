CREATE TABLE IF NOT EXISTS `Books` (
  `id` int(11) NOT NULL,
  `author` longtext NOT NULL,
  `launch_date` datetime NOT NULL,
  `price` decimal NOT NULL,
  `title` longtext NOT NULL,
PRIMARY KEY(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;