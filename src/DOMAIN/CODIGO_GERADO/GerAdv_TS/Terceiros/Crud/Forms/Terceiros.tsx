// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITerceiros } from '@/app/GerAdv_TS/Terceiros/Interfaces/interface.Terceiros';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import PosicaoOutrasPartesComboBox from '@/app/GerAdv_TS/PosicaoOutrasPartes/ComboBox/PosicaoOutrasPartes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { PosicaoOutrasPartesApi } from '@/app/GerAdv_TS/PosicaoOutrasPartes/Apis/ApiPosicaoOutrasPartes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface TerceirosFormProps {
    terceirosData: ITerceiros;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TerceirosForm: React.FC<TerceirosFormProps> = ({
    terceirosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePosicaoOutrasPartes, setNomePosicaoOutrasPartes] = useState('');
            const posicaooutraspartesApi = new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (terceirosData.id === 0) {
    terceirosData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("posicaooutraspartes") > 0) {
  posicaooutraspartesApi
    .getById(getParamFromUrl("posicaooutraspartes"))
    .then((response) => {
      setNomePosicaoOutrasPartes(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (terceirosData.id === 0) {
    terceirosData.situacao = getParamFromUrl("posicaooutraspartes");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        terceirosData.processo = e.id;
                      };
 const addValorSituacao = (e: any) => {
                        if (e?.id>0)
                        terceirosData.situacao = e.id;
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
        console.error("Erro ao submeter formulário de Terceiros:", error);
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
          target: document.getElementById(`TerceirosForm-${terceirosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Terceiros diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Terceiros' : 'form-container form-container-Terceiros'}>
       
            <form className='formInputCadInc' id={`TerceirosForm-${terceirosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={terceirosData} isSubmitting={isSubmitting} onClose={onClose} formId={`TerceirosForm-${terceirosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={terceirosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={terceirosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <PosicaoOutrasPartesComboBox
            name={'situacao'}
            value={terceirosData.situacao}
            setValue={addValorSituacao}
            label={'Posicao Outras Partes'}
            />

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={terceirosData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={terceirosData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={terceirosData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={terceirosData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={terceirosData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={terceirosData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={terceirosData.obs}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={terceirosData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={terceirosData.class}
onChange={onChange}               
/>

<InputInput
type="text"
id="varaforocomarca"
label="VaraForoComarca"
className="inputIncNome"
name="varaforocomarca"
value={terceirosData.varaforocomarca}
onChange={onChange}               
/>

<InputCheckbox label="Sexo" name="sexo" checked={terceirosData.sexo} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 