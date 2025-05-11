// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGUTAtividades } from '@/app/GerAdv_TS/GUTAtividades/Interfaces/interface.GUTAtividades';
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

import GUTPeriodicidadeComboBox from '@/app/GerAdv_TS/GUTPeriodicidade/ComboBox/GUTPeriodicidade';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { GUTPeriodicidadeApi } from '@/app/GerAdv_TS/GUTPeriodicidade/Apis/ApiGUTPeriodicidade';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface GUTAtividadesFormProps {
    gutatividadesData: IGUTAtividades;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTAtividadesForm: React.FC<GUTAtividadesFormProps> = ({
    gutatividadesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTPeriodicidade, setNomeGUTPeriodicidade] = useState('');
            const gutperiodicidadeApi = new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("gutperiodicidade") > 0) {
  gutperiodicidadeApi
    .getById(getParamFromUrl("gutperiodicidade"))
    .then((response) => {
      setNomeGUTPeriodicidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutatividadesData.id === 0) {
    gutatividadesData.gutperiodicidade = getParamFromUrl("gutperiodicidade");
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

  if (gutatividadesData.id === 0) {
    gutatividadesData.operador = getParamFromUrl("operador");
  }
}
 const addValorGUTPeriodicidade = (e: any) => {
                        if (e?.id>0)
                        gutatividadesData.gutperiodicidade = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        gutatividadesData.operador = e.id;
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
        console.error("Erro ao submeter formulário de GUTAtividades:", error);
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
          target: document.getElementById(`GUTAtividadesForm-${gutatividadesData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar GUTAtividades diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-GUTAtividades' : 'form-container5 form-container-GUTAtividades'}>
       
            <form className='formInputCadInc' id={`GUTAtividadesForm-${gutatividadesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gutatividadesData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTAtividadesForm-${gutatividadesData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={gutatividadesData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={gutatividadesData.observacao}
onChange={onChange}               
/>

<InputInput
type="text"
id="gutgrupo"
label="GUTGrupo"
className="inputIncNome"
name="gutgrupo"
value={gutatividadesData.gutgrupo}
onChange={onChange}               
/>

            <GUTPeriodicidadeComboBox
            name={'gutperiodicidade'}
            value={gutatividadesData.gutperiodicidade}
            setValue={addValorGUTPeriodicidade}
            label={'G U T Periodicidade'}
            />

            <OperadorComboBox
            name={'operador'}
            value={gutatividadesData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputCheckbox label="Concluido" name="concluido" checked={gutatividadesData.concluido} onChange={onChange} />
        
<InputInput
type="text"
id="dataconcluido"
label="DataConcluido"
className="inputIncNome"
name="dataconcluido"
value={gutatividadesData.dataconcluido}
onChange={onChange}               
/>

<InputInput
type="text"
id="diasparainiciar"
label="DiasParaIniciar"
className="inputIncNome"
name="diasparainiciar"
value={gutatividadesData.diasparainiciar}
onChange={onChange}               
/>

<InputInput
type="text"
id="minutospararealizar"
label="MinutosParaRealizar"
className="inputIncNome"
name="minutospararealizar"
value={gutatividadesData.minutospararealizar}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 