--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2024-01-22 11:51:42

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "ssoUM";
--
-- TOC entry 3371 (class 1262 OID 75126)
-- Name: ssoUM; Type: DATABASE; Schema: -; Owner: -
--

CREATE DATABASE "ssoUM" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';


\connect "ssoUM"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA public;


--
-- TOC entry 3372 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 75149)
-- Name: app; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.app (
    aid bigint NOT NULL,
    redirecturl character varying(100) NOT NULL,
    jid bigint
);


--
-- TOC entry 218 (class 1259 OID 75148)
-- Name: app_aid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.app_aid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3373 (class 0 OID 0)
-- Dependencies: 218
-- Name: app_aid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.app_aid_seq OWNED BY public.app.aid;


--
-- TOC entry 217 (class 1259 OID 75137)
-- Name: jwt; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.jwt (
    jid bigint NOT NULL,
    description character varying(30) NOT NULL,
    kid bigint
);


--
-- TOC entry 216 (class 1259 OID 75136)
-- Name: jwt_jid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.jwt_jid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3374 (class 0 OID 0)
-- Dependencies: 216
-- Name: jwt_jid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.jwt_jid_seq OWNED BY public.jwt.jid;


--
-- TOC entry 215 (class 1259 OID 75128)
-- Name: keys; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.keys (
    kid bigint NOT NULL,
    type smallint NOT NULL,
    private_key character varying NOT NULL,
    public_key character varying,
    algo character varying(30) NOT NULL
);


--
-- TOC entry 214 (class 1259 OID 75127)
-- Name: keys_kid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.keys_kid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3375 (class 0 OID 0)
-- Dependencies: 214
-- Name: keys_kid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.keys_kid_seq OWNED BY public.keys.kid;


--
-- TOC entry 221 (class 1259 OID 75161)
-- Name: role; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.role (
    rid bigint NOT NULL,
    r_pid bigint,
    role_code character varying(30) NOT NULL,
    aid bigint
);


--
-- TOC entry 220 (class 1259 OID 75160)
-- Name: role_rid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.role_rid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3376 (class 0 OID 0)
-- Dependencies: 220
-- Name: role_rid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.role_rid_seq OWNED BY public.role.rid;


--
-- TOC entry 223 (class 1259 OID 75178)
-- Name: user; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."user" (
    uid bigint NOT NULL,
    aid bigint NOT NULL,
    rid bigint,
    username character varying(100) NOT NULL,
    password_hash character varying(100) NOT NULL,
    password_salt character varying(100) NOT NULL
);


--
-- TOC entry 222 (class 1259 OID 75177)
-- Name: user_uid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.user_uid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3377 (class 0 OID 0)
-- Dependencies: 222
-- Name: user_uid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.user_uid_seq OWNED BY public."user".uid;


--
-- TOC entry 3195 (class 2604 OID 75152)
-- Name: app aid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.app ALTER COLUMN aid SET DEFAULT nextval('public.app_aid_seq'::regclass);


--
-- TOC entry 3194 (class 2604 OID 75140)
-- Name: jwt jid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.jwt ALTER COLUMN jid SET DEFAULT nextval('public.jwt_jid_seq'::regclass);


--
-- TOC entry 3193 (class 2604 OID 75131)
-- Name: keys kid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.keys ALTER COLUMN kid SET DEFAULT nextval('public.keys_kid_seq'::regclass);


--
-- TOC entry 3196 (class 2604 OID 75164)
-- Name: role rid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.role ALTER COLUMN rid SET DEFAULT nextval('public.role_rid_seq'::regclass);


--
-- TOC entry 3197 (class 2604 OID 75181)
-- Name: user uid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user" ALTER COLUMN uid SET DEFAULT nextval('public.user_uid_seq'::regclass);


--
-- TOC entry 3361 (class 0 OID 75149)
-- Dependencies: 219
-- Data for Name: app; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3359 (class 0 OID 75137)
-- Dependencies: 217
-- Data for Name: jwt; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3357 (class 0 OID 75128)
-- Dependencies: 215
-- Data for Name: keys; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3363 (class 0 OID 75161)
-- Dependencies: 221
-- Data for Name: role; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3365 (class 0 OID 75178)
-- Dependencies: 223
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3378 (class 0 OID 0)
-- Dependencies: 218
-- Name: app_aid_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.app_aid_seq', 1, false);


--
-- TOC entry 3379 (class 0 OID 0)
-- Dependencies: 216
-- Name: jwt_jid_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.jwt_jid_seq', 1, false);


--
-- TOC entry 3380 (class 0 OID 0)
-- Dependencies: 214
-- Name: keys_kid_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.keys_kid_seq', 1, false);


--
-- TOC entry 3381 (class 0 OID 0)
-- Dependencies: 220
-- Name: role_rid_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.role_rid_seq', 1, false);


--
-- TOC entry 3382 (class 0 OID 0)
-- Dependencies: 222
-- Name: user_uid_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.user_uid_seq', 1, false);


--
-- TOC entry 3203 (class 2606 OID 75154)
-- Name: app app_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.app
    ADD CONSTRAINT app_pk PRIMARY KEY (aid);


--
-- TOC entry 3201 (class 2606 OID 75142)
-- Name: jwt jwt_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.jwt
    ADD CONSTRAINT jwt_pk PRIMARY KEY (jid);


--
-- TOC entry 3199 (class 2606 OID 75135)
-- Name: keys keys_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.keys
    ADD CONSTRAINT keys_pk PRIMARY KEY (kid);


--
-- TOC entry 3205 (class 2606 OID 75166)
-- Name: role role_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pk PRIMARY KEY (rid);


--
-- TOC entry 3207 (class 2606 OID 75183)
-- Name: user user_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (uid);


--
-- TOC entry 3209 (class 2606 OID 75155)
-- Name: app app_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.app
    ADD CONSTRAINT app_fk FOREIGN KEY (jid) REFERENCES public.jwt(jid) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 3208 (class 2606 OID 75143)
-- Name: jwt jwt_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.jwt
    ADD CONSTRAINT jwt_fk FOREIGN KEY (kid) REFERENCES public.keys(kid) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 3210 (class 2606 OID 75167)
-- Name: role role_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_fk FOREIGN KEY (r_pid) REFERENCES public.role(rid);


--
-- TOC entry 3211 (class 2606 OID 75172)
-- Name: role role_t_app_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_t_app_fk FOREIGN KEY (aid) REFERENCES public.app(aid) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 3212 (class 2606 OID 75184)
-- Name: user user_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_fk FOREIGN KEY (aid) REFERENCES public.app(aid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3213 (class 2606 OID 75189)
-- Name: user user_t_role_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_t_role_fk FOREIGN KEY (rid) REFERENCES public.role(rid);


-- Completed on 2024-01-22 11:51:42

--
-- PostgreSQL database dump complete
--

