"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ICargos } from '../../Interfaces/interface.Cargos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface CargosFormProps {
    cargosData: ICargos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const CargosForm: React.FC<CargosFormProps> = ({
    cargosData,
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
            value={cargosData.nome}
            onChange={onChange}
            required
          />

          							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/advogados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cargos=${cargosData.id}`)}>Advogados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/colaboradores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cargos=${cargosData.id}`)}>Colaboradores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/funcionarios${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cargos=${cargosData.id}`)}>Colaborador</div>

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
 