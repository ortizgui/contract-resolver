# ContractResolver

Exemplo de modelo para retorno de campos informados pela Query String `fields`.

## Exemplo de requests

Request default

```cmd
curl --request GET \
  --url http://localhost:5114/v1/accounts/101099
```

Request com filtro de campos

```cmd
curl --request GET \
  --url 'http://localhost:5114/v1/accounts/101099?fields=id%2Cnumber'
```

Request informando um campo inválido

```cmd
curl --request GET \
  --url 'http://localhost:5114/v1/accounts/101099?fields=id%2Cmodel'
```