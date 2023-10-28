DROP TABLE IF EXISTS `tickets`;
CREATE TABLE `tickets` (
    `ownerId` varchar(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
    `code` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
    `discountType` int(10) unsigned DEFAULT NULL,
    `createdAt` datetime DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY `code` (`code`),
    UNIQUE KEY `ownerId` (`ownerId`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;