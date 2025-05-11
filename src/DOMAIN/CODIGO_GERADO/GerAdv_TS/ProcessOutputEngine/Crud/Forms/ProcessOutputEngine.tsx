// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProcessOutputEngine } from '@/app/GerAdv_TS/ProcessOutputEngine/Interfaces/interface.ProcessOutputEngine';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ProcessOutputEngineFormProps {
    processoutputengineData: IProcessOutputEngine;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProcessOutputEngineForm: React.FC<ProcessOutputEngineFormProps> = ({
    processoutputengineData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
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
        console.error("Erro ao submeter formulário de ProcessOutputEngine:", error);
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
          target: document.getElementById(`ProcessOutputEngineForm-${processoutputengineData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ProcessOutputEngine diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ProcessOutputEngine' : 'form-container form-container-ProcessOutputEngine'}>
       
            <form className='formInputCadInc' id={`ProcessOutputEngineForm-${processoutputengineData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={processoutputengineData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessOutputEngineForm-${processoutputengineData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={processoutputengineData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="database"
label="Database"
className="inputIncNome"
name="database"
value={processoutputengineData.database}
onChange={onChange}               
/>

<InputInput
type="text"
id="tabela"
label="Tabela"
className="inputIncNome"
name="tabela"
value={processoutputengineData.tabela}
onChange={onChange}               
/>

<InputInput
type="text"
id="campo"
label="Campo"
className="inputIncNome"
name="campo"
value={processoutputengineData.campo}
onChange={onChange}               
/>

<InputInput
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={processoutputengineData.valor}
onChange={onChange}               
/>

<InputInput
type="text"
id="output"
label="Output"
className="inputIncNome"
name="output"
value={processoutputengineData.output}
onChange={onChange}               
/>

<InputCheckbox label="Administrador" name="administrador" checked={processoutputengineData.administrador} onChange={onChange} />
        
<InputInput
type="text"
id="outputsource"
label="OutputSource"
className="inputIncNome"
name="outputsource"
value={processoutputengineData.outputsource}
onChange={onChange}               
/>

<InputCheckbox label="DisabledItem" name="disableditem" checked={processoutputengineData.disableditem} onChange={onChange} />
        
<InputInput
type="text"
id="idmodulo"
label="IDModulo"
className="inputIncNome"
name="idmodulo"
value={processoutputengineData.idmodulo}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="IsOnlyProcesso" name="isonlyprocesso" checked={processoutputengineData.isonlyprocesso} onChange={onChange} />
        
<InputInput
type="text"
id="myid"
label="MyID"
className="inputIncNome"
name="myid"
value={processoutputengineData.myid}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 