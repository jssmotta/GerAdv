"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IGUTTipo } from '../../Interfaces/interface.GUTTipo';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface GUTTipoFormProps {
    guttipoData: IGUTTipo;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTTipoForm: React.FC<GUTTipoFormProps> = ({
    guttipoData,
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
            value={guttipoData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="ordem"
label="Ordem"
className="inputIncNome"
name="ordem"
value={guttipoData.ordem}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gutmatriz${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?guttipo=${guttipoData.id}`)}>G U T Matriz</div>

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
 