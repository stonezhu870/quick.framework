/*
Navicat MariaDB Data Transfer

Source Server         : mariadb
Source Server Version : 100207
Source Host           : localhost:3306
Source Database       : yudb

Target Server Type    : MariaDB
Target Server Version : 100207
File Encoding         : 65001

Date: 2017-08-28 17:30:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for sys_func
-- ----------------------------
DROP TABLE IF EXISTS `sys_func`;
CREATE TABLE `sys_func` (
  `id` bigint(20) NOT NULL,
  `func_cnname` varchar(255) NOT NULL,
  `func_name` varchar(255) NOT NULL,
  `func_icon` varchar(255) DEFAULT NULL,
  `func_sort` smallint(6) NOT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `create_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  `creator` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_func
-- ----------------------------
INSERT INTO `sys_func` VALUES ('15344542552064', '添加', 'add', 'plus', '1', null, '2017-08-25 10:43:52', 'admin');
INSERT INTO `sys_func` VALUES ('15435793829888', '编辑', 'edit', 'edit', '2', null, '2017-08-25 10:44:14', 'admin');
INSERT INTO `sys_func` VALUES ('15519788961792', '删除', 'del', 'times', '33', null, '2017-08-25 10:58:09', 'admin');

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu` (
  `id` varchar(32) NOT NULL,
  `menu_name` varchar(255) NOT NULL,
  `menu_url` varchar(255) NOT NULL,
  `menu_sort` smallint(5) NOT NULL,
  `menu_type` tinyint(1) NOT NULL,
  `parent_id` char(32) DEFAULT '',
  `menu_font` varchar(50) DEFAULT '',
  `menu_icon` varchar(50) DEFAULT '',
  `remark` varchar(255) DEFAULT '',
  `creator` varchar(255) NOT NULL,
  `create_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES ('1c686abcef4d4c8f957b98c62d285cad', '菜单管理', '/sysmenu/index', '2', '0', 'f934cbded5f04f1f9e8fc007c06fc5d3', null, null, null, 'admin', '2017-08-24 15:51:32');
INSERT INTO `sys_menu` VALUES ('2a13632490464fedb1739ed175f566d5', '角色管理', '/sysrole/index', '3', '0', 'f934cbded5f04f1f9e8fc007c06fc5d3', null, null, '角色管理', 'admin', '2017-08-24 16:29:52');
INSERT INTO `sys_menu` VALUES ('36d566d78c9146f8bbfd706db518b484', '用户管理', '/sysuser/index', '1', '0', 'f934cbded5f04f1f9e8fc007c06fc5d3', 'da', null, null, 'admin', '2017-08-24 16:26:42');
INSERT INTO `sys_menu` VALUES ('9ec29fb0222343f68ba35793021dd569', '按钮管理', '/sysfunc/index', '4', '0', 'f934cbded5f04f1f9e8fc007c06fc5d3', null, null, null, 'admin', '2017-08-25 10:16:40');
INSERT INTO `sys_menu` VALUES ('f934cbded5f04f1f9e8fc007c06fc5d3', '系统管理', '/System', '1', '0', null, null, null, '系统管理', 'admin', '2017-08-24 14:22:08');

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `id` char(32) NOT NULL,
  `role_name` varchar(255) NOT NULL,
  `creator` varchar(255) NOT NULL,
  `create_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  `role_code` varchar(255) DEFAULT '',
  `remark` varchar(255) DEFAULT '' COMMENT '''''',
  `sort` smallint(4) NOT NULL,
  `status` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES ('906bb2cac08d45598836315751af17aa', '系统管理员', 'admin', '2017-08-24 17:18:28', null, '系统管理员', '1', '1');

-- ----------------------------
-- Table structure for sys_role_authorize
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_authorize`;
CREATE TABLE `sys_role_authorize` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_id` char(36) NOT NULL,
  `menu_id` char(36) NOT NULL,
  `menu_pid` char(36) NOT NULL,
  `creator` varchar(255) NOT NULL,
  `create_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role_authorize
-- ----------------------------

-- ----------------------------
-- Table structure for sys_role_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_user`;
CREATE TABLE `sys_role_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_id` char(36) NOT NULL,
  `user_id` char(36) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role_user
-- ----------------------------

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `id` char(32) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nickname` varchar(255) NOT NULL,
  `id_number` varchar(255) DEFAULT '',
  `tel` varchar(255) DEFAULT '',
  `mobile_tel` varchar(255) DEFAULT '',
  `gender` tinyint(4) DEFAULT NULL,
  `head_photo` varchar(255) DEFAULT '',
  `province` varchar(255) DEFAULT '',
  `city` varchar(255) DEFAULT '',
  `county` varchar(255) DEFAULT '',
  `village` varchar(255) DEFAULT '',
  `role` varchar(255) DEFAULT '',
  `status` tinyint(1) NOT NULL,
  `create_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  `creator` varchar(255) NOT NULL,
  `remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('92ed299447cf41a1905c2d9069955691', 'admin', '123123', '超级管理员', '320922199004063918', null, '15961820351', '1', null, null, null, null, null, null, '0', '2017-08-24 16:26:29', 'app', null);
SET FOREIGN_KEY_CHECKS=1;
