"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IOperadorGruposAgendaOperadores } from '../../Interfaces/interface.OperadorGruposAgendaOperadores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorGruposAgendaComboBox from '@/app/GerAdv_TS/OperadorGruposAgenda/ComboBox/OperadorGruposAgenda';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorGruposAgendaApi } from '@/app/GerAdv_TS/OperadorGruposAgenda/Apis/ApiOperadorGruposAgenda';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';

interface OperadorGruposAgendaOperadoresFormProps {
    operadorgruposagendaoperadoresData: IOperadorGruposAgendaOperadores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorGruposAgendaOperadoresForm: React.FC<OperadorGruposAgendaOperadoresFormProps> = ({
    operadorgruposagendaoperadoresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperadorGruposAgenda, setNomeOperadorGruposAgenda] = useState('');
            const operadorgruposagendaApi = new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operadorgruposagenda") > 0) {
  operadorgruposagendaApi
    .getById(getParamFromUrl("operadorgruposagenda"))
    .then((response) => {
      setNomeOperadorGruposAgenda(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgruposagendaoperadoresData.id === 0) {
    operadorgruposagendaoperadoresData.operadorgruposagenda = getParamFromUrl("operadorgruposagenda");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgruposagendaoperadoresData.id === 0) {
    operadorgruposagendaoperadoresData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperadorGruposAgenda = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaoperadoresData.operadorgruposagenda = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaoperadoresData.operador = e.id;
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
  {nomeOperadorGruposAgenda && (<h2>{nomeOperadorGruposAgenda}</h2>)}
{nomeOperador && (<h2>{nomeOperador}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <OperadorGruposAgendaComboBox
            name={'operadorgruposagenda'}
            value={operadorgruposagendaoperadoresData.operadorgruposagenda}
            setValue={addValorOperadorGruposAgenda}
            label={'Operador Grupos Agenda'}
            />

            <OperadorComboBox
            name={'operador'}
            value={operadorgruposagendaoperadoresData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

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
 