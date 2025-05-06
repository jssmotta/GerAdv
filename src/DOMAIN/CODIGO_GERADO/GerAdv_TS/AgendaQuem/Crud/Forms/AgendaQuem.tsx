// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaQuem } from '@/app/GerAdv_TS/AgendaQuem/Interfaces/interface.AgendaQuem';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import InputName from '@/app/components/Inputs/InputName';

interface AgendaQuemFormProps {
    agendaquemData: IAgendaQuem;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaQuemForm: React.FC<AgendaQuemFormProps> = ({
    agendaquemData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
            const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
            const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendaquemData.id === 0) {
    agendaquemData.advogado = getParamFromUrl("advogados");
  }
}
 
if (getParamFromUrl("funcionarios") > 0) {
  funcionariosApi
    .getById(getParamFromUrl("funcionarios"))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendaquemData.id === 0) {
    agendaquemData.funcionario = getParamFromUrl("funcionarios");
  }
}
 
if (getParamFromUrl("prepostos") > 0) {
  prepostosApi
    .getById(getParamFromUrl("prepostos"))
    .then((response) => {
      setNomePrepostos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendaquemData.id === 0) {
    agendaquemData.preposto = getParamFromUrl("prepostos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        agendaquemData.advogado = e.id;
                      };
 const addValorFuncionario = (e: any) => {
                        if (e?.id>0)
                        agendaquemData.funcionario = e.id;
                      };
 const addValorPreposto = (e: any) => {
                        if (e?.id>0)
                        agendaquemData.preposto = e.id;
                      };

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
      const formElement = document.getElementById('AgendaQuemForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AgendaQuemForm-${agendaquemData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendaquemData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaQuemForm-${agendaquemData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="idagenda"
label="IDAgenda"
className="inputIncNome"
name="idagenda"
value={agendaquemData.idagenda}
onChange={onChange}               
/>

            <AdvogadosComboBox
            name={'advogado'}
            value={agendaquemData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

            <FuncionariosComboBox
            name={'funcionario'}
            value={agendaquemData.funcionario}
            setValue={addValorFuncionario}
            label={'Colaborador'}
            />

            <PrepostosComboBox
            name={'preposto'}
            value={agendaquemData.preposto}
            setValue={addValorPreposto}
            label={'Prepostos'}
            />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 