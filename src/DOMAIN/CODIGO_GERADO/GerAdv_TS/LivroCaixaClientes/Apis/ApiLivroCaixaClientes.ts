import axios, { AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterLivroCaixaClientes } from "../Filters/LivroCaixaClientes"
import { LivroCaixaClientes } from "../../Models/LivroCaixaClientes";
import { ILivroCaixaClientes } from '../Interfaces/interface.LivroCaixaClientes';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';

export class LivroCaixaClientesApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;

    constructor(uri: string, authorization: string, version: number = parseInt(process.env.NEXT_PUBLIC_URL_VERSION_API ?? '2')) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API_BASE}${version}/${uri}/LivroCaixaClientes`;
        this.notificationService = new NotificationService();
    }

    private getHeaders() {
        return {
            headers: {
                Authorization: `Bearer ${decodeBase64Token(this.authorization)}`,
                'Content-Type': 'application/json',
                'Cache-Control': 'no-cache',     
            },
        };
    }

    private createNotificationEntity(
        id: number, 
        action: NotifySystemActions = NotifySystemActions.DELETE): INotifySystemEntity {
        return {
            entity: "LivroCaixaClientes",
            id: id,
            action: action
        };
    }

    public async getAll(max: number = 1000): Promise<AxiosResponse> {
        return axios.get(`${this.baseUrl}/GetAll?max=${max}`, this.getHeaders());
    }

    public async getById(id: number): Promise<AxiosResponse> {
        return await axios.get(`${this.baseUrl}/GetById/${id}`, this.getHeaders());
    }

    public async filter(filtro: FilterLivroCaixaClientes): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async addAndUpdate(regLivroCaixaClientes: ILivroCaixaClientes): Promise<AxiosResponse> {
        try {
            var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regLivroCaixaClientes as LivroCaixaClientes, this.getHeaders());
            var register = result.data as ILivroCaixaClientes;        
            const action = regLivroCaixaClientes.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
            const notificationEntity = this.createNotificationEntity(register.id, action);        
            this.notificationService.notify(notificationEntity);
            return result; } 
        catch (error: any) {
            if (error.response && error.response.status === 409) {
                if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Erro de validação, o registro já existe
                    const errorMessage = message || 'Verifique se o registro já existe!';
                    this.notificationService.notify({
                        entity: "LivroCaixaClientes",
                        id: regLivroCaixaClientes.id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });

                }
            }
            throw error;
        }
    }

    public async delete(id: number): Promise<AxiosResponse | void> {
        try {
            const result = await axios.delete(`${this.baseUrl}/Delete?id=${id}`, this.getHeaders());
             if (result.data) {
                if (result.data.success === false) {
                    throw new Error(result.data.message || 'Erro ao excluir.');
                }
                const notificationEntity = this.createNotificationEntity(id, NotifySystemActions.DELETE);
                this.notificationService.notify(notificationEntity);
            }
            return result;
        } catch (error: any) {
            if (error.response && error.response.status === 409) {
              if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Conflito, o registro está vinculado a outros registros
                    const errorMessage = message|| 'Erro ao excluir o LivroCaixaClientes. Verifique se ele não está vinculado a outros registros.';
                    this.notificationService.notify({
                        entity: "LivroCaixaClientes",
                        id: id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });
                    throw new Error(error.data.message || 'Erro ao excluir.');
                }
            }
            throw error;                   
        }
    }

    public useFilter(filtro: FilterLivroCaixaClientes) {
        const url = `${this.baseUrl}/Filter`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<LivroCaixaClientes[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

}
