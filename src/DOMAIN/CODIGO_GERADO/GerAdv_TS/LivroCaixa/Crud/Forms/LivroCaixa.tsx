// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ILivroCaixa } from '@/app/GerAdv_TS/LivroCaixa/Interfaces/interface.LivroCaixa';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('LivroCaixaForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`LivroCaixaForm-${livrocaixaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={livrocaixaData} isSubmitting={isSubmitting} onClose={onClose} formId={`LivroCaixaForm-${livrocaixaData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="iddes"
label="IDDes"
className="inputIncNome"
name="iddes"
value={livrocaixaData.iddes}
onChange={onChange}               
/>

<Input
type="text"
id="pessoal"
label="Pessoal"
className="inputIncNome"
name="pessoal"
value={livrocaixaData.pessoal}
onChange={onChange}               
/>

<InputCheckbox label="Ajuste" name="ajuste" checked={livrocaixaData.ajuste} onChange={onChange} />
        
<Input
type="text"
id="idhon"
label="IDHon"
className="inputIncNome"
name="idhon"
value={livrocaixaData.idhon}
onChange={onChange}               
/>

<Input
type="text"
id="idhonparc"
label="IDHonParc"
className="inputIncNome"
name="idhonparc"
value={livrocaixaData.idhonparc}
onChange={onChange}               
/>

<InputCheckbox label="IDHonSuc" name="idhonsuc" checked={livrocaixaData.idhonsuc} onChange={onChange} />
        
<Input
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

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={livrocaixaData.valor}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Tipo" name="tipo" checked={livrocaixaData.tipo} onChange={onChange} />
        
<Input
type="text"
id="historico"
label="Historico"
className="inputIncNome"
name="historico"
value={livrocaixaData.historico}
onChange={onChange}               
/>

<Input
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
        
    </>
     );
};
 