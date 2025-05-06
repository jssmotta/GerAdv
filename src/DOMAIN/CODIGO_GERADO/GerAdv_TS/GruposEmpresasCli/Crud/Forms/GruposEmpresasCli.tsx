// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGruposEmpresasCli } from '@/app/GerAdv_TS/GruposEmpresasCli/Interfaces/interface.GruposEmpresasCli';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import GruposEmpresasComboBox from '@/app/GerAdv_TS/GruposEmpresas/ComboBox/GruposEmpresas';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { GruposEmpresasApi } from '@/app/GerAdv_TS/GruposEmpresas/Apis/ApiGruposEmpresas';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

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

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('GruposEmpresasCliForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`GruposEmpresasCliForm-${gruposempresascliData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gruposempresascliData} isSubmitting={isSubmitting} onClose={onClose} formId={`GruposEmpresasCliForm-${gruposempresascliData.id}`} />

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

<InputCheckbox label="Oculto" name="oculto" checked={gruposempresascliData.oculto} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 