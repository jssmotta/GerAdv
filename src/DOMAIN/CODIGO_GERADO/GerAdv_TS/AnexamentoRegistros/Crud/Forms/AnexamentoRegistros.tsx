// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAnexamentoRegistros } from '@/app/GerAdv_TS/AnexamentoRegistros/Interfaces/interface.AnexamentoRegistros';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

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
  const isMobile = useIsMobile();
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de AnexamentoRegistros:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AnexamentoRegistros diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AnexamentoRegistros' : 'form-container5 form-container-AnexamentoRegistros'}>
       
            <form className='formInputCadInc' id={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={anexamentoregistrosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={anexamentoregistrosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="guidreg"
label="GUIDReg"
className="inputIncNome"
name="guidreg"
value={anexamentoregistrosData.guidreg}
onChange={onChange}               
/>

<InputInput
type="text"
id="codigoreg"
label="CodigoReg"
className="inputIncNome"
name="codigoreg"
value={anexamentoregistrosData.codigoreg}
onChange={onChange}               
/>

<InputInput
type="text"
id="idreg"
label="IDReg"
className="inputIncNome"
name="idreg"
value={anexamentoregistrosData.idreg}
onChange={onChange}               
/>

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 