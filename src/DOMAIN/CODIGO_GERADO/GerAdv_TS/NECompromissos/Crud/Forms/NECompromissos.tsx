"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { INECompromissos } from '../../Interfaces/interface.NECompromissos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import TipoCompromissoComboBox from '@/app/GerAdv_TS/TipoCompromisso/ComboBox/TipoCompromisso';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/ApiTipoCompromisso';

interface NECompromissosFormProps {
    necompromissosData: INECompromissos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const NECompromissosForm: React.FC<NECompromissosFormProps> = ({
    necompromissosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoCompromisso, setNomeTipoCompromisso] = useState('');
            const tipocompromissoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipocompromisso") > 0) {
  tipocompromissoApi
    .getById(getParamFromUrl("tipocompromisso"))
    .then((response) => {
      setNomeTipoCompromisso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (necompromissosData.id === 0) {
    necompromissosData.tipocompromisso = getParamFromUrl("tipocompromisso");
  }
}
 const addValorTipoCompromisso = (e: any) => {
                        if (e?.id>0)
                        necompromissosData.tipocompromisso = e.id;
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
  {nomeTipoCompromisso && (<h2>{nomeTipoCompromisso}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="palavrachave"
label="PalavraChave"
className="inputIncNome"
name="palavrachave"
value={necompromissosData.palavrachave}
onChange={onChange}               
/>

<Checkbox label="Provisionar" name="provisionar" checked={necompromissosData.provisionar} onChange={onChange} />
 
            <TipoCompromissoComboBox
            name={'tipocompromisso'}
            value={necompromissosData.tipocompromisso}
            setValue={addValorTipoCompromisso}
            label={'Tipo Compromisso'}
            />

<Input
type="text"
id="textocompromisso"
label="TextoCompromisso"
className="inputIncNome"
name="textocompromisso"
value={necompromissosData.textocompromisso}
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
 