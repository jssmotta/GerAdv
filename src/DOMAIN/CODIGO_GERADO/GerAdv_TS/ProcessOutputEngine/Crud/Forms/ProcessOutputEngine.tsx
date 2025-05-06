// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProcessOutputEngine } from '@/app/GerAdv_TS/ProcessOutputEngine/Interfaces/interface.ProcessOutputEngine';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';
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
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
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
      const formElement = document.getElementById('ProcessOutputEngineForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`ProcessOutputEngineForm-${processoutputengineData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={processoutputengineData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessOutputEngineForm-${processoutputengineData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={processoutputengineData.nome}
            placeholder={`Digite nome process output engine`}
            onChange={onChange}
            required
          />

<Input
type="text"
id="database"
label="Database"
className="inputIncNome"
name="database"
value={processoutputengineData.database}
onChange={onChange}               
/>

<Input
type="text"
id="tabela"
label="Tabela"
className="inputIncNome"
name="tabela"
value={processoutputengineData.tabela}
onChange={onChange}               
/>

<Input
type="text"
id="campo"
label="Campo"
className="inputIncNome"
name="campo"
value={processoutputengineData.campo}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={processoutputengineData.valor}
onChange={onChange}               
/>

<Input
type="text"
id="output"
label="Output"
className="inputIncNome"
name="output"
value={processoutputengineData.output}
onChange={onChange}               
/>

<InputCheckbox label="Administrador" name="administrador" checked={processoutputengineData.administrador} onChange={onChange} />
        
<Input
type="text"
id="outputsource"
label="OutputSource"
className="inputIncNome"
name="outputsource"
value={processoutputengineData.outputsource}
onChange={onChange}               
/>

<InputCheckbox label="DisabledItem" name="disableditem" checked={processoutputengineData.disableditem} onChange={onChange} />
        
<Input
type="text"
id="idmodulo"
label="IDModulo"
className="inputIncNome"
name="idmodulo"
value={processoutputengineData.idmodulo}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="IsOnlyProcesso" name="isonlyprocesso" checked={processoutputengineData.isonlyprocesso} onChange={onChange} />
        
<Input
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
        
    </>
     );
};
 