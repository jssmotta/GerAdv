"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ISituacao } from '../../Interfaces/interface.Situacao';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface SituacaoFormProps {
    situacaoData: ISituacao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const SituacaoForm: React.FC<SituacaoFormProps> = ({
    situacaoData,
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
id="parte_int"
label="Parte_Int"
className="inputIncNome"
name="parte_int"
value={situacaoData.parte_int}
onChange={onChange}               
/>

<Input
type="text"
id="parte_opo"
label="Parte_Opo"
className="inputIncNome"
name="parte_opo"
value={situacaoData.parte_opo}
onChange={onChange}               
/>

<Checkbox label="Top" name="top" checked={situacaoData.top} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?situacao=${situacaoData.id}`)}>Processos</div>

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
 