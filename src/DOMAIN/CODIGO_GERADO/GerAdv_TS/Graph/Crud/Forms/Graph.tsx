// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGraph } from '@/app/GerAdv_TS/Graph/Interfaces/interface.Graph';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';

interface GraphFormProps {
    graphData: IGraph;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GraphForm: React.FC<GraphFormProps> = ({
    graphData,
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
      const formElement = document.getElementById('GraphForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`GraphForm-${graphData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={graphData} isSubmitting={isSubmitting} onClose={onClose} formId={`GraphForm-${graphData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="tabela"
label="Tabela"
className="inputIncNome"
name="tabela"
value={graphData.tabela}
onChange={onChange}               
/>

<Input
type="text"
id="tabelaid"
label="TabelaId"
className="inputIncNome"
name="tabelaid"
value={graphData.tabelaid}
onChange={onChange}               
/>

<Input
type="text"
id="imagem"
label="Imagem"
className="inputIncNome"
name="imagem"
value={graphData.imagem}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 