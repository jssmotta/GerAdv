'use client';
import axios, { AxiosError, AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterDiario2 } from '../Filters/Diario2'
import { Diario2 } from '../../Models/Diario2';
import { IDiario2 } from '../Interfaces/interface.Diario2';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';
import {CRUD_CONSTANTS} from '@/app/tools/crud';


export class Diario2ApiError extends Error {
  status: number;
  code?: string;
  originalError?: any;

  constructor(message: string, status: number, code?: string, originalError?: any) {
    super(message);
    this.name = 'Diario2ApiError';
    this.status = status;
    this.code = code;
    this.originalError = originalError;
  }

  toString() {
    return `${this.name}: ${this.message} (status: ${this.status})`;
  }
}

export class Diario2Api {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;
    private uri: string;

    constructor(uri: string, authorization: string, version: number = parseInt(process.env.NEXT_PUBLIC_URL_VERSION_API ?? '1')) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API_BASE}${version}/${uri}/Diario2`;
        this.notificationService = new NotificationService();
        this.uri = uri;
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
            entity: 'Diario2',
            id: id,
            action: action
        };
    }

    private createNotificationOffLiveEntity(
        id: number,
        action: NotifySystemActions = NotifySystemActions.INFO,
        message?: string): INotifySystemEntity {
        return {
            entity: 'Diario2',
            id: id,
            action: action,
            message: message ?? `Trabalhando off-line.`
        };
    }


    private handleApiError(error: any, context: string): never {
        if (axios.isAxiosError(error)) {
            const axiosError = error as AxiosError;
            const status = axiosError.response?.status || 500;
            const message = (axiosError.response?.data as { message?: string })?.message || axiosError.message;

            this.notificationService.notify(
                this.createNotificationOffLiveEntity(0, NotifySystemActions.ERROR, message ?? 'Erro desconhecido')
            );

            throw new Diario2ApiError(
                `${context}: ${message}`,
                status,
                axiosError.code,
                error
            );
        }
        else {
            this.notificationService.notify(
                this.createNotificationOffLiveEntity(0, NotifySystemActions.ERROR, 'Erro desconhecido')
            );
        }

        throw new Diario2ApiError(
            `${context}: Erro desconhecido`,
            500,
            'UNKNOWN_ERROR',
            error
        );
    }


   
        public async getAll(max: number = CRUD_CONSTANTS.DEFAULT_MAX_RECORDS): Promise<AxiosResponse> {
        const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-Diario2_last_getAll_${max}`);
        try {
            const response = await axios.get(`${this.baseUrl}/GetAll?max=${max}`, this.getHeaders());
            const encoded = btoa(JSON.stringify(response.data));
            localStorage.setItem(storageKey, encoded);
            return response;
        } catch (error: any) {
            const offlineData = localStorage.getItem(storageKey);
            if (offlineData) {
                const decoded = JSON.parse(atob(offlineData));
                this.notificationService.notify(
                    this.createNotificationOffLiveEntity(0, NotifySystemActions.INFO)
                );
                return {
                    data: decoded,
                    status: 200,
                    statusText: 'OK (offline)',
                    headers: {},
                    config: {},
                } as AxiosResponse;
            }
            this.handleApiError(error, 'Erro ao buscar todos os Diario2');
        }
    }
    
        public async getById(id: number): Promise<AxiosResponse> {
        const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-Diario2_last_getById_${id}`);
        try {
            const response = await axios.get(`${this.baseUrl}/GetById/${id}`, this.getHeaders());
            
        const encoded = btoa(JSON.stringify(response.data));
        localStorage.setItem(storageKey, encoded);
            return response;
        } catch (error: any) {
            const offlineData = localStorage.getItem(storageKey);
            if (offlineData) {
                const decoded = JSON.parse(atob(offlineData));
                this.notificationService.notify(
                    this.createNotificationOffLiveEntity(id, NotifySystemActions.INFO)
                );
                return {
                    data: decoded,
                    status: 200,
                    statusText: 'OK (offline)',
                    headers: {},
                    config: {},
                } as AxiosResponse;
            }
            this.handleApiError(error, `Erro ao buscar Diario2 com ID ${id}`);
        }
    }
    
        public async getListN(max?: number, filtro?: FilterDiario2): Promise<AxiosResponse> {
        if (max === undefined) max = CRUD_CONSTANTS.DEFAULT_MAX_RECORDS;
        const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-Diario2_last_listN_data`);

        try {
            const response = await axios.post(`${this.baseUrl}/GetListN/?max=${max}`, filtro, this.getHeaders());
            
        const encoded = btoa(JSON.stringify(response.data));
        localStorage.setItem(storageKey, encoded);
            return response;
        } catch (error: any) {
            const offlineData = localStorage.getItem(storageKey);
            if (offlineData) {
                const decoded = JSON.parse(atob(offlineData));
                this.notificationService.notify(
                    this.createNotificationOffLiveEntity(0, NotifySystemActions.INFO)
                );
                return {
                    data: decoded,
                    status: 200,
                    statusText: 'OK (offline)',
                    headers: {},
                    config: {},
                } as AxiosResponse;
            }
            this.handleApiError(error, 'Erro ao buscar lista de Diario2');
        }
    }

            public async filter(filtro: FilterDiario2): Promise<AxiosResponse> {
                const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-Diario2_last_filter_data_${JSON.stringify(filtro)}`);
                try {
                    const response = await axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
                    
        const encoded = btoa(JSON.stringify(response.data));
        localStorage.setItem(storageKey, encoded);
                    return response;
                } catch (error: any) {
                    const offlineData = localStorage.getItem(storageKey);
                    if (offlineData) {
                        const decoded = JSON.parse(atob(offlineData));
                        this.notificationService.notify(
                            this.createNotificationOffLiveEntity(0, NotifySystemActions.INFO)
                        );
                        return {
                            data: decoded,
                            status: 200,
                            statusText: 'OK (offline)',
                            headers: {},
                            config: {},
                        } as AxiosResponse;
                    }

                    this.handleApiError(error, 'Erro ao filtrar Diario2');
                }
            }


    public async validation(regDiario2: IDiario2): Promise<{ isValid: boolean; message: string } | null> {
        try {
            const result = await axios.post(`${this.baseUrl}/validation`, regDiario2 as Diario2, this.getHeaders());
            // Se a resposta for bem-sucedida, retorna true
            return { isValid: true, message: 'Validação bem-sucedida' };
        } catch (error: any) {
            if (error.response && (error.response.status === 409 || error.response.status === 500)) {
                if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Erro de validação, o registro já existe
                    const errorMessage = message || 'Verifique se o registro já existe!';
                    return { isValid: false, message: errorMessage };                    
                }
            }
            return { isValid: false, message: 'Erro desconhecido ao validar na base.' };;
        }
    }


    public async addAndUpdate(regDiario2: IDiario2): Promise<AxiosResponse> {
        try {
            var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regDiario2 as Diario2, this.getHeaders());
            var register = result.data as IDiario2;        
            const action = regDiario2.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
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
                        entity: 'Diario2',
                        id: regDiario2.id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });

                }
            }

            this.handleApiError(error, 'Erro ao salvar Diario2');
        }
    }

    public async delete(id: number): Promise<AxiosResponse | void> {
        try {
            const result = await axios.delete(`${this.baseUrl}/Delete?id=${id}`, this.getHeaders());
             if (result.data) {
                /* if (result.data.success === false) {
                    throw new Error(result.data.message || 'Erro ao excluir.');
                } */
                const notificationEntity = this.createNotificationEntity(id, NotifySystemActions.DELETE);
                this.notificationService.notify(notificationEntity);
            }
            return result;
        } catch (error: any) {
            if (error.response && error.response.status === 409) {
              if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Conflito, o registro está vinculado a outros registros
                    const errorMessage = message|| 'Erro ao excluir o Diario2. Verifique se ele não está vinculado a outros registros.';
                    this.notificationService.notify({
                        entity: 'Diario2',
                        id: id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });
                    throw new Error(error.data.message || 'Erro ao excluir.');
                }
            }
             this.handleApiError(error, `Erro ao excluir Diario2 com ID ${id}`);                
        }
    }




    public useFilter(filtro: FilterDiario2) {
       const url = `${this.baseUrl}/Filter`;
       const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
    
        return useSWR<Diario2[]>(key, fetcher, {
          revalidateOnFocus: false,
          revalidateOnReconnect: false,
          onError: (error) => {
            console.error('Erro no SWR para filtro de diario2:', error);
            this.notificationService.notify({
              entity: 'Diario2',
              id: 0,
              action: NotifySystemActions.ERROR,
              message: 'Erro ao carregar dados dos diario2'
            });
          }
        });
    }

}
