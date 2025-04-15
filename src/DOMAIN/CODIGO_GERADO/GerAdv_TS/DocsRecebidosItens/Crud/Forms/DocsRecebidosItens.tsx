"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IDocsRecebidosItens } from '../../Interfaces/interface.DocsRecebidosItens';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';

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

  return (
  <>
  {nomeContatoCRM && (<h2>{nomeContatoCRM}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={docsrecebidositensData.nome}
            onChange={onChange}
            required
          />

            <ContatoCRMComboBox
            name={'contatocrm'}
            value={docsrecebidositensData.contatocrm}
            setValue={addValorContatoCRM}
            label={'Contato C R M'}
            />

<Checkbox label="Devolvido" name="devolvido" checked={docsrecebidositensData.devolvido} onChange={onChange} />
<Checkbox label="SeraDevolvido" name="seradevolvido" checked={docsrecebidositensData.seradevolvido} onChange={onChange} />
        
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
 