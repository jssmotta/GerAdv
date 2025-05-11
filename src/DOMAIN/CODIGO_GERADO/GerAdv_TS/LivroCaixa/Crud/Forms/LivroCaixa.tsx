// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ILivroCaixa } from '@/app/GerAdv_TS/LivroCaixa/Interfaces/interface.LivroCaixa';
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
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface LivroCaixaFormProps {
    livrocaixaData: ILivroCaixa;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const LivroCaixaForm: React.FC<LivroCaixaFormProps> = ({
    livrocaixaData,
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
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (livrocaixaData.id === 0) {
    livrocaixaData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        livrocaixaData.processo = e.id;
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
        console.error("Erro ao submeter formulário de LivroCaixa:", error);
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
          target: document.getElementById(`LivroCaixaForm-${livrocaixaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar LivroCaixa diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-LivroCaixa' : 'form-container form-container-LivroCaixa'}>
       
            <form className='formInputCadInc' id={`LivroCaixaForm-${livrocaixaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={livrocaixaData} isSubmitting={isSubmitting} onClose={onClose} formId={`LivroCaixaForm-${livrocaixaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="iddes"
label="IDDes"
className="inputIncNome"
name="iddes"
value={livrocaixaData.iddes}
onChange={onChange}               
/>

<InputInput
type="text"
id="pessoal"
label="Pessoal"
className="inputIncNome"
name="pessoal"
value={livrocaixaData.pessoal}
onChange={onChange}               
/>

<InputCheckbox label="Ajuste" name="ajuste" checked={livrocaixaData.ajuste} onChange={onChange} />
        
<InputInput
type="text"
id="idhon"
label="IDHon"
className="inputIncNome"
name="idhon"
value={livrocaixaData.idhon}
onChange={onChange}               
/>

<InputInput
type="text"
id="idhonparc"
label="IDHonParc"
className="inputIncNome"
name="idhonparc"
value={livrocaixaData.idhonparc}
onChange={onChange}               
/>

<InputCheckbox label="IDHonSuc" name="idhonsuc" checked={livrocaixaData.idhonsuc} onChange={onChange} />
        
<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={livrocaixaData.data}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={livrocaixaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={livrocaixaData.valor}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Tipo" name="tipo" checked={livrocaixaData.tipo} onChange={onChange} />
        
<InputInput
type="text"
id="historico"
label="Historico"
className="inputIncNome"
name="historico"
value={livrocaixaData.historico}
onChange={onChange}               
/>

<InputInput
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={livrocaixaData.grupo}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 