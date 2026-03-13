'use client';
import axios, { AxiosRequestConfig } from 'axios';
import useSWR from 'swr';
import { decodeBase64Token } from '../../tools/Fetcher';
// Raw shape as it likely comes from the API (PascalCase from C#)
interface AuditorResponse {
  id: number;
  tableName: string;
  nomeQuemCadastrou: string;
  nomeQuemAlterou: string;
  dataHoraCadastro: string;
  dataHoraAlteracao: string;
  checked: boolean;
}

// Public interface (camelCase) as you specified
export interface Auditor {
  id: number;
  tableName: string;
  nomeQuemCadastrou: string;
  nomeQuemAlterou: string;
  dataHoraCadastro: string;
  dataHoraAlteracao: string;
  checked: boolean;
}

// Map API (PascalCase) to frontend (camelCase)
function mapAuditor(r: AuditorResponse): Auditor {
  return {
    id: r.id,
    tableName: r.tableName,
    nomeQuemCadastrou: r.nomeQuemCadastrou,
    nomeQuemAlterou: r.nomeQuemAlterou,
    dataHoraCadastro: r.dataHoraCadastro,
    dataHoraAlteracao: r.dataHoraAlteracao,
    checked: r.checked,
  };
}

// Generic GET fetcher using the key pattern `${url}::${token}`
const getFetcher = async (key: string) => {
  const [url, token] = key.split('::');
  const cfg: AxiosRequestConfig = {
    method: 'GET',
    url,
    headers: {
      Authorization: `Bearer ${decodeBase64Token(token)}`,
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
    },
  };
  const resp = await axios(cfg);

  if (resp.status === 204) return null;
  if (resp.status === 200) return resp.data;
  throw new Error(`Unexpected status ${resp.status}`);
};

// setCheck performs a GET against AuditorCheck endpoint which returns a boolean or 204
const setCheck = async (key: string): Promise<boolean | null> => {
  const [url, token] = key.split('::');
  const cfg: AxiosRequestConfig = {
    method: 'GET',
    url,
    headers: {
      Authorization: `Bearer ${decodeBase64Token(token)}`,
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
    },
    // don't transform response; axios will parse JSON automatically
  };

  const resp = await axios(cfg);

  // Some endpoints return 204 when not found / no content
  if (resp.status === 204) return null;

  // For check endpoint we expect a boolean in the body with 200
  if (resp.status === 200) {
    // Ensure the response data is a boolean (coerce if needed)
    const d = resp.data;
    if (typeof d === 'boolean') return d;
    // If API returns { value: true } or similar, try to extract
    if (d && typeof d === 'object' && 'value' in d) return Boolean((d as any).value);
    // If it's a string like "true"/"false"
    if (typeof d === 'string') return d.toLowerCase() === 'true';
    // If it's numeric 0/1
    if (typeof d === 'number') return d !== 0;
    // Otherwise, return null to indicate unexpected shape
    return null;
  }

  throw new Error(`Unexpected status ${resp.status}`);
};

export class AuditorApi {
  private token: string;
  private tenantKey: string;   

  constructor(tenantKey: string, token: string) {
    this.tenantKey = tenantKey;
    this.token = token;
  }

  // Build the endpoint URL
  private buildUrl(entityName: string, check: boolean, id: number) {
    const apiRoot = process.env.NEXT_PUBLIC_URL_API;
    if (!apiRoot) {
      throw new Error('NEXT_PUBLIC_URL_API not defined');
    }    
    return `${apiRoot}/${this.tenantKey}/Auditor${check? "Check":""}/${entityName}/${id}`;
  }

  // // SWR hook
  useAuditor(entityName: string, check: boolean, id: number) {
    const url = this.buildUrl(entityName, check, id);    
    const key = `${url}::${this.token}`; 

    const { data, error, isLoading, mutate } = useSWR<any | null>(
      key,
      getFetcher,     
      {
        revalidateOnFocus: false,
        revalidateOnReconnect: false,
      }
    );

    return {
      data: data ? mapAuditor(data) : null,
      error,
      isLoading,
      mutate,
    };
  }

  // Direct (imperative) fetch
  async fetchAuditor(entityName: string, id: number): Promise<Auditor | null> {
    const url = this.buildUrl(entityName, false, id);
    const key = `${url}::${this.token}`;
    const raw = (await getFetcher(key)) as AuditorResponse | null;
    return raw ? mapAuditor(raw) : null;
  }

  async checkAuditor(entityName: string, id: number): Promise<boolean | null> {
    const url = this.buildUrl(entityName, true, id);
    const key = `${url}::${this.token}`;
    const raw = (await setCheck(key)) as boolean | null;
    return raw ;
  }
}

// Example usage (React component):
// const auditorApi = new AuditorApi('minhaTenantApp', tokenBase64);
// const { data, isLoading, error } = auditorApi.useAuditor('Clientes', 123);