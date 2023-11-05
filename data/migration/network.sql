DROP TABLE IF EXISTS `network`;
CREATE TABLE `network` (
  `id` varchar(36) COLLATE utf8mb4_unicode_ci NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `city` varchar(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `street` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `streetNo` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ownership` varchar(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ord` smallint(5) unsigned DEFAULT NULL,
  `registrationCode` varchar(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;