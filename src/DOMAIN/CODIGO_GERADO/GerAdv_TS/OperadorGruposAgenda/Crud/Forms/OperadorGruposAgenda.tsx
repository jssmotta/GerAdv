"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IOperadorGruposAgenda } from '../../Interfaces/interface.OperadorGruposAgenda';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';

interface OperadorGruposAgendaFormProps {
    operadorgruposagendaData: IOperadorGruposAgenda;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorGruposAgendaForm: React.FC<OperadorGruposAgendaFormProps> = ({
    operadorgruposagendaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgruposagendaData.id === 0) {
    operadorgruposagendaData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaData.operador = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeOperador && (<h2>{nomeOperador}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={operadorgruposagendaData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="sqlwhere"
label="SQLWhere"
className="inputIncNome"
name="sqlwhere"
value={operadorgruposagendaData.sqlwhere}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={operadorgruposagendaData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operadorgruposagendaoperadores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operadorgruposagenda=${operadorgruposagendaData.id}`)}>Operador Grupos Agenda Operadores</div>

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
 