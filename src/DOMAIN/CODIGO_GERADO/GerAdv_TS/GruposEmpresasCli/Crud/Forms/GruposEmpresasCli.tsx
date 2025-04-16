"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IGruposEmpresasCli } from '../../Interfaces/interface.GruposEmpresasCli';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import GruposEmpresasComboBox from '@/app/GerAdv_TS/GruposEmpresas/ComboBox/GruposEmpresas';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { GruposEmpresasApi } from '@/app/GerAdv_TS/GruposEmpresas/Apis/ApiGruposEmpresas';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

interface GruposEmpresasCliFormProps {
    gruposempresascliData: IGruposEmpresasCli;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GruposEmpresasCliForm: React.FC<GruposEmpresasCliFormProps> = ({
    gruposempresascliData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGruposEmpresas, setNomeGruposEmpresas] = useState('');
            const gruposempresasApi = new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("gruposempresas") > 0) {
  gruposempresasApi
    .getById(getParamFromUrl("gruposempresas"))
    .then((response) => {
      setNomeGruposEmpresas(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresascliData.id === 0) {
    gruposempresascliData.grupo = getParamFromUrl("gruposempresas");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresascliData.id === 0) {
    gruposempresascliData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorGrupo = (e: any) => {
                        if (e?.id>0)
                        gruposempresascliData.grupo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        gruposempresascliData.cliente = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeGruposEmpresas && (<h2>{nomeGruposEmpresas}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <GruposEmpresasComboBox
            name={'grupo'}
            value={gruposempresascliData.grupo}
            setValue={addValorGrupo}
            label={'Grupos Empresas'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={gruposempresascliData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Checkbox label="Oculto" name="oculto" checked={gruposempresascliData.oculto} onChange={onChange} />

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 