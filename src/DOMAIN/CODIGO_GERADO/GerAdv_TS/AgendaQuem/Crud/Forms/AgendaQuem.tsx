// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaQuem } from '@/app/GerAdv_TS/AgendaQuem/Interfaces/interface.AgendaQuem';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
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
import InputInput from '@/app/components/Inputs/InputInput'

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
  const isMobile = useIsMobile();
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de AgendaQuem:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`AgendaQuemForm-${agendaquemData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AgendaQuem diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AgendaQuem' : 'form-container5 form-container-AgendaQuem'}>
       
            <form className='formInputCadInc' id={`AgendaQuemForm-${agendaquemData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendaquemData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaQuemForm-${agendaquemData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 