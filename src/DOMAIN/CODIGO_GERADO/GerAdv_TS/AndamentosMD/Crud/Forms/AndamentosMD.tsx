// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAndamentosMD } from '@/app/GerAdv_TS/AndamentosMD/Interfaces/interface.AndamentosMD';
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

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface AndamentosMDFormProps {
    andamentosmdData: IAndamentosMD;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AndamentosMDForm: React.FC<AndamentosMDFormProps> = ({
    andamentosmdData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (andamentosmdData.id === 0) {
    andamentosmdData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        andamentosmdData.processo = e.id;
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
        console.error("Erro ao submeter formulário de AndamentosMD:", error);
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
          target: document.getElementById(`AndamentosMDForm-${andamentosmdData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AndamentosMD diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AndamentosMD' : 'form-container5 form-container-AndamentosMD'}>
       
            <form className='formInputCadInc' id={`AndamentosMDForm-${andamentosmdData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={andamentosmdData} isSubmitting={isSubmitting} onClose={onClose} formId={`AndamentosMDForm-${andamentosmdData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={andamentosmdData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={andamentosmdData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="andamento"
label="Andamento"
className="inputIncNome"
name="andamento"
value={andamentosmdData.andamento}
onChange={onChange}               
/>

<InputInput
type="text"
id="pathfull"
label="PathFull"
className="inputIncNome"
name="pathfull"
value={andamentosmdData.pathfull}
onChange={onChange}               
/>

<InputInput
type="text"
id="unc"
label="UNC"
className="inputIncNome"
name="unc"
value={andamentosmdData.unc}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 