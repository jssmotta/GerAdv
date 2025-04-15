import axios, { AxiosResponse } from 'axios';

const baseUrl = `${process.env.REACT_APP_URL}/api/v1/clientes`;
 
class ClientesService {
    private authorization: string;

    constructor(authorization: string) {
        this.authorization = authorization;
    }

    private getHeaders() {
        return {
            headers: {
                Authorization: this.authorization,
            },
        };
    }

    public async getAll(max: number = 1000): Promise<AxiosResponse> {
        return axios.get(`${baseUrl}/GetAll?max=${max}`, this.getHeaders());
    }

    public async filter(filtro: FilterClientes): Promise<AxiosResponse> {
        return axios.post(`${baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async getById(id: number): Promise<AxiosResponse> {
        return axios.get(`${baseUrl}/GetById/${id}`, this.getHeaders());
    }

    public async getByName(name: string): Promise<AxiosResponse> {
        return axios.get(`${baseUrl}/GetByName/${name}`, this.getHeaders());
    }

    public async addAndUpdate(regClientes: Clientes): Promise<AxiosResponse> {
        return axios.post(`${baseUrl}/AddAndUpdate`, regClientes, this.getHeaders());
    }

    public async getColumns(parameters: GetColumns): Promise<AxiosResponse> {
        return axios.post(`${baseUrl}/GetColumns`, parameters, this.getHeaders());
    }

    public async updateColumns(parameters: UpdateColumnsRequest): Promise<AxiosResponse> {
        return axios.post(`${baseUrl}/UpdateColumns`, parameters, this.getHeaders());
    }

    public async getListN(): Promise<AxiosResponse> {
        return axios.get(`${baseUrl}/GetListN`, this.getHeaders());
    }

    public async delete(id: number): Promise<AxiosResponse> {
        return axios.delete(`${baseUrl}/Delete/${id}`, this.getHeaders());
    }
}

// Exemplo de uso:
const authorizationToken = 'Bearer your-token-here';
const clientesService = new ClientesService(authorizationToken);

// Chamada de exemplo:
clientesService.getAll().then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});


// Chamada de exemplo para filter:
const filtro: FilterClientes = { /* parâmetros do filtro */ };
clientesService.filter(filtro).then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para getById:
clientesService.getById(1).then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para getByName:
clientesService.getByName('John Doe').then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para addAndUpdate:
const regClientes: Clientes = { /* dados do cliente */ };
clientesService.addAndUpdate(regClientes).then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para getColumns:
const getColumnsParams: GetColumns = { /* parâmetros para obter colunas */ };
clientesService.getColumns(getColumnsParams).then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para updateColumns:
const updateColumnsParams: UpdateColumnsRequest = { /* parâmetros para atualizar colunas */ };
clientesService.updateColumns(updateColumnsParams).then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para getListN:
clientesService.getListN().then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});

// Chamada de exemplo para delete:
clientesService.delete(1).then(response => {
    console.log(response.data);
}).catch(error => {
    console.error(error);
});