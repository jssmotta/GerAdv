"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProcessOutputEngine } from '../../Interfaces/interface.ProcessOutputEngine';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

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

  return (
  <>
  
    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={processoutputengineData.nome}
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

<Checkbox label="Administrador" name="administrador" checked={processoutputengineData.administrador} onChange={onChange} />
        
<Input
type="text"
id="outputsource"
label="OutputSource"
className="inputIncNome"
name="outputsource"
value={processoutputengineData.outputsource}
onChange={onChange}               
/>

<Checkbox label="DisabledItem" name="disableditem" checked={processoutputengineData.disableditem} onChange={onChange} />
        
<Input
type="text"
id="idmodulo"
label="IDModulo"
className="inputIncNome"
name="idmodulo"
value={processoutputengineData.idmodulo}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="IsOnlyProcesso" name="isonlyprocesso" checked={processoutputengineData.isonlyprocesso} onChange={onChange} />
        
<Input
type="text"
id="myid"
label="MyID"
className="inputIncNome"
name="myid"
value={processoutputengineData.myid}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processoutputrequest${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processoutputengine=${processoutputengineData.id}`)}>Process Output Request</div>

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
 