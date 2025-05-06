// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGruposEmpresas } from '@/app/GerAdv_TS/GruposEmpresas/Interfaces/interface.GruposEmpresas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputDescription from '@/app/components/Inputs/InputDescription';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface GruposEmpresasFormProps {
    gruposempresasData: IGruposEmpresas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GruposEmpresasForm: React.FC<GruposEmpresasFormProps> = ({
    gruposempresasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOponentes, setNomeOponentes] = useState('');
            const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("oponentes") > 0) {
  oponentesApi
    .getById(getParamFromUrl("oponentes"))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresasData.id === 0) {
    gruposempresasData.oponente = getParamFromUrl("oponentes");
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

  if (gruposempresasData.id === 0) {
    gruposempresasData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorOponente = (e: any) => {
                        if (e?.id>0)
                        gruposempresasData.oponente = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        gruposempresasData.cliente = e.id;
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
      const formElement = document.getElementById('GruposEmpresasForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`GruposEmpresasForm-${gruposempresasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gruposempresasData} isSubmitting={isSubmitting} onClose={onClose} formId={`GruposEmpresasForm-${gruposempresasData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={gruposempresasData.descricao}
            placeholder={`Digite nome grupos empresas`}
            onChange={onChange}
            required
            disabled={gruposempresasData.id > 0}
          />

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={gruposempresasData.email}
onChange={onChange}               
/>

<InputCheckbox label="Inativo" name="inativo" checked={gruposempresasData.inativo} onChange={onChange} />
 
            <OponentesComboBox
            name={'oponente'}
            value={gruposempresasData.oponente}
            setValue={addValorOponente}
            label={'Oponentes'}
            />

<Input
type="text"
id="observacoes"
label="Observacoes"
className="inputIncNome"
name="observacoes"
value={gruposempresasData.observacoes}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={gruposempresasData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={gruposempresasData.icone}
onChange={onChange}               
/>

<InputCheckbox label="DespesaUnificada" name="despesaunificada" checked={gruposempresasData.despesaunificada} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 