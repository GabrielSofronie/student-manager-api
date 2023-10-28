DROP TABLE IF EXISTS `students`;
CREATE TABLE `students` (
    `id` varchar(36) COLLATE utf8mb4_unicode_ci NOT NULL,
    `email` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
    `password` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
    `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
    `institutionId` varchar(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
    `ticketId` varchar(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
    `registrationNumber` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
    `createdAt` datetime DEFAULT CURRENT_TIMESTAMP,
    `login` datetime DEFAULT CURRENT_TIMESTAMP,
    `faculty` text COLLATE utf8mb4_unicode_ci,
    PRIMARY KEY (`id`),
    UNIQUE KEY `registrationNumber` (`registrationNumber`),
    UNIQUE KEY `email` (`email`),
    UNIQUE KEY `ticketId` (`ticketId`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;