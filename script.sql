CREATE TABLE cluster (
    cluster_id SERIAL PRIMARY KEY,
    unique_id UUID,
    name VARCHAR(250) NOT NULL,
    status VARCHAR(50) NOT NULL,
    load_balancing_policy VARCHAR(500),
    session_affinity JSONB,
    health_check JSONB,
    http_client JSONB,
    http_request JSONB,
    metadata JSONB,
    created_date TIMESTAMPTZ,
    updated_date TIMESTAMPTZ
);

CREATE TABLE destination (
    destination_id SERIAL PRIMARY KEY,
    address character varying(250) NOT NULL,
    health character varying(250),
    cluster_id integer NOT NULL,
    created_date TIMESTAMPTZ,
    updated_date TIMESTAMPTZ,
    metadata jsonb
);

CREATE TABLE proxy_route (
    proxy_route_id SERIAL PRIMARY KEY,
    route_id VARCHAR(250),
    match JSONB NOT NULL,
    "order" INTEGER,
    cluster_id INTEGER NOT NULL,
    created_date TIMESTAMP,
    updated_date TIMESTAMP,
    authorization_policy VARCHAR(250),
    cors_policy VARCHAR(250),
    metadata JSONB,
    transforms JSONB
);