"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IArea } from '../../Interfaces/interface.Area';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface AreaFormProps {
    areaData: IArea;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AreaForm: React.FC<AreaFormProps> = ({
    areaData,
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
            value={areaData.descricao}
            onChange={onChange}
            required
          />

          <Checkbox label="Top" name="top" checked={areaData.top} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/acao${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Acao</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/areasjustica${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Areas Justica</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/divisaotribunal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Divisao Tribunal</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/fase${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Fase</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/objetos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Objetos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/poderjudiciarioassociado${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Poder Judiciario Associado</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Processos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/tiporecurso${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Tipo Recurso</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/tribunal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?area=${areaData.id}`)}>Tribunal</div>

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
 