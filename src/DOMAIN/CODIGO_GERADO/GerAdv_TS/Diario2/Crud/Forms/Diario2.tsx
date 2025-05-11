// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IDiario2 } from '@/app/GerAdv_TS/Diario2/Interfaces/interface.Diario2';
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

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface Diario2FormProps {
    diario2Data: IDiario2;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const Diario2Form: React.FC<Diario2FormProps> = ({
    diario2Data,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (diario2Data.id === 0) {
    diario2Data.operador = getParamFromUrl("operador");
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

  if (diario2Data.id === 0) {
    diario2Data.cliente = getParamFromUrl("clientes");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        diario2Data.operador = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        diario2Data.cliente = e.id;
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
        console.error("Erro ao submeter formulário de Diario2:", error);
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
          target: document.getElementById(`Diario2Form-${diario2Data.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Diario2 diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Diario2' : 'form-container5 form-container-Diario2'}>
       
            <form className='formInputCadInc' id={`Diario2Form-${diario2Data.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={diario2Data} isSubmitting={isSubmitting} onClose={onClose} formId={`Diario2Form-${diario2Data.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={diario2Data.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={diario2Data.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={diario2Data.hora}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={diario2Data.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
type="text"
id="ocorrencia"
label="Ocorrencia"
className="inputIncNome"
name="ocorrencia"
value={diario2Data.ocorrencia}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={diario2Data.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 