﻿"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IFuncao } from '../../Interfaces/interface.Funcao';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface FuncaoFormProps {
    funcaoData: IFuncao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const FuncaoForm: React.FC<FuncaoFormProps> = ({
    funcaoData,
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
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={funcaoData.descricao}
            onChange={onChange}
            required
          />

          							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/funcionarios${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?funcao=${funcaoData.id}`)}>Colaborador</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/prepostos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?funcao=${funcaoData.id}`)}>Prepostos</div>

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
 