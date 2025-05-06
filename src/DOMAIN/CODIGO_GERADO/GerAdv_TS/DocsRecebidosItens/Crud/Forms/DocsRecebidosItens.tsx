// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IDocsRecebidosItens } from '@/app/GerAdv_TS/DocsRecebidosItens/Interfaces/interface.DocsRecebidosItens';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('DocsRecebidosItensForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`DocsRecebidosItensForm-${docsrecebidositensData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={docsrecebidositensData} isSubmitting={isSubmitting} onClose={onClose} formId={`DocsRecebidosItensForm-${docsrecebidositensData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={docsrecebidositensData.nome}
            placeholder={`Digite nome docs recebidos itens`}
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
        
<Input
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
        
    </>
     );
};
 