// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAnexamentoRegistros } from '@/app/GerAdv_TS/AnexamentoRegistros/Interfaces/interface.AnexamentoRegistros';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';

interface AnexamentoRegistrosFormProps {
    anexamentoregistrosData: IAnexamentoRegistros;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AnexamentoRegistrosForm: React.FC<AnexamentoRegistrosFormProps> = ({
    anexamentoregistrosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (anexamentoregistrosData.id === 0) {
    anexamentoregistrosData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        anexamentoregistrosData.cliente = e.id;
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
      const formElement = document.getElementById('AnexamentoRegistrosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={anexamentoregistrosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} />

                <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={anexamentoregistrosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="guidreg"
label="GUIDReg"
className="inputIncNome"
name="guidreg"
value={anexamentoregistrosData.guidreg}
onChange={onChange}               
/>

<Input
type="text"
id="codigoreg"
label="CodigoReg"
className="inputIncNome"
name="codigoreg"
value={anexamentoregistrosData.codigoreg}
onChange={onChange}               
/>

<Input
type="text"
id="idreg"
label="IDReg"
className="inputIncNome"
name="idreg"
value={anexamentoregistrosData.idreg}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={anexamentoregistrosData.data}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 