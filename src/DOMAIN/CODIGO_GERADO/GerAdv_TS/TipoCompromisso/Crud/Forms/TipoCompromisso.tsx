"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ITipoCompromisso } from '../../Interfaces/interface.TipoCompromisso';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface TipoCompromissoFormProps {
    tipocompromissoData: ITipoCompromisso;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoCompromissoForm: React.FC<TipoCompromissoFormProps> = ({
    tipocompromissoData,
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
            value={tipocompromissoData.descricao}
            onChange={onChange}
            required
          />

<Input
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={tipocompromissoData.icone}
onChange={onChange}               
/>

<Checkbox label="Financeiro" name="financeiro" checked={tipocompromissoData.financeiro} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tipocompromisso=${tipocompromissoData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tipocompromisso=${tipocompromissoData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/necompromissos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tipocompromisso=${tipocompromissoData.id}`)}>N E Compromissos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendasemana${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tipocompromisso=${tipocompromissoData.id}`)}>Agenda Semana</div>

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
 