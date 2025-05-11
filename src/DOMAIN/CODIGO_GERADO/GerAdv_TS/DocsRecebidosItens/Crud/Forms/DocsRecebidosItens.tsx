// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IDocsRecebidosItens } from '@/app/GerAdv_TS/DocsRecebidosItens/Interfaces/interface.DocsRecebidosItens';
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

import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'

interface DocsRecebidosItensFormProps {
    docsrecebidositensData: IDocsRecebidosItens;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const DocsRecebidosItensForm: React.FC<DocsRecebidosItensFormProps> = ({
    docsrecebidositensData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeContatoCRM, setNomeContatoCRM] = useState('');
            const contatocrmApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("contatocrm") > 0) {
  contatocrmApi
    .getById(getParamFromUrl("contatocrm"))
    .then((response) => {
      setNomeContatoCRM(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (docsrecebidositensData.id === 0) {
    docsrecebidositensData.contatocrm = getParamFromUrl("contatocrm");
  }
}
 const addValorContatoCRM = (e: any) => {
                        if (e?.id>0)
                        docsrecebidositensData.contatocrm = e.id;
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
        console.error("Erro ao submeter formulário de DocsRecebidosItens:", error);
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
          target: document.getElementById(`DocsRecebidosItensForm-${docsrecebidositensData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar DocsRecebidosItens diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-DocsRecebidosItens' : 'form-container5 form-container-DocsRecebidosItens'}>
       
            <form className='formInputCadInc' id={`DocsRecebidosItensForm-${docsrecebidositensData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={docsrecebidositensData} isSubmitting={isSubmitting} onClose={onClose} formId={`DocsRecebidosItensForm-${docsrecebidositensData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={docsrecebidositensData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <ContatoCRMComboBox
            name={'contatocrm'}
            value={docsrecebidositensData.contatocrm}
            setValue={addValorContatoCRM}
            label={'Contato C R M'}
            />

<InputCheckbox label="Devolvido" name="devolvido" checked={docsrecebidositensData.devolvido} onChange={onChange} />
<InputCheckbox label="SeraDevolvido" name="seradevolvido" checked={docsrecebidositensData.seradevolvido} onChange={onChange} />
        
<InputInput
type="text"
id="observacoes"
label="Observacoes"
className="inputIncNome"
name="observacoes"
value={docsrecebidositensData.observacoes}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 