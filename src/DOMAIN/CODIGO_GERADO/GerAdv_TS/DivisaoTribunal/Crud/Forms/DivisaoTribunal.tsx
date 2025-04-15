"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IDivisaoTribunal } from '../../Interfaces/interface.DivisaoTribunal';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import TribunalComboBox from '@/app/GerAdv_TS/Tribunal/ComboBox/Tribunal';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';
import { TribunalApi } from '@/app/GerAdv_TS/Tribunal/Apis/ApiTribunal';
import InputCep from '@/app/components/Inputs/InputCep'

interface DivisaoTribunalFormProps {
    divisaotribunalData: IDivisaoTribunal;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const DivisaoTribunalForm: React.FC<DivisaoTribunalFormProps> = ({
    divisaotribunalData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
            const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTribunal, setNomeTribunal] = useState('');
            const tribunalApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("justica") > 0) {
  justicaApi
    .getById(getParamFromUrl("justica"))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (divisaotribunalData.id === 0) {
    divisaotribunalData.justica = getParamFromUrl("justica");
  }
}
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (divisaotribunalData.id === 0) {
    divisaotribunalData.area = getParamFromUrl("area");
  }
}
 
if (getParamFromUrl("foro") > 0) {
  foroApi
    .getById(getParamFromUrl("foro"))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (divisaotribunalData.id === 0) {
    divisaotribunalData.foro = getParamFromUrl("foro");
  }
}
 
if (getParamFromUrl("tribunal") > 0) {
  tribunalApi
    .getById(getParamFromUrl("tribunal"))
    .then((response) => {
      setNomeTribunal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (divisaotribunalData.id === 0) {
    divisaotribunalData.tribunal = getParamFromUrl("tribunal");
  }
}
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        divisaotribunalData.justica = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        divisaotribunalData.area = e.id;
                      };
 const addValorForo = (e: any) => {
                        if (e?.id>0)
                        divisaotribunalData.foro = e.id;
                      };
 const addValorTribunal = (e: any) => {
                        if (e?.id>0)
                        divisaotribunalData.tribunal = e.id;
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
  {nomeJustica && (<h2>{nomeJustica}</h2>)}
{nomeArea && (<h2>{nomeArea}</h2>)}
{nomeForo && (<h2>{nomeForo}</h2>)}
{nomeTribunal && (<h2>{nomeTribunal}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="numcodigo"
label="NumCodigo"
className="inputIncNome"
name="numcodigo"
value={divisaotribunalData.numcodigo}
onChange={onChange}               
/>

            <JusticaComboBox
            name={'justica'}
            value={divisaotribunalData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

<Input
type="text"
id="nomeespecial"
label="NomeEspecial"
className="inputIncNome"
name="nomeespecial"
value={divisaotribunalData.nomeespecial}
onChange={onChange}               
/>

            <AreaComboBox
            name={'area'}
            value={divisaotribunalData.area}
            setValue={addValorArea}
            label={'Area'}
            />

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={divisaotribunalData.cidade}
onChange={onChange}               
/>

            <ForoComboBox
            name={'foro'}
            value={divisaotribunalData.foro}
            setValue={addValorForo}
            label={'Foro'}
            />

            <TribunalComboBox
            name={'tribunal'}
            value={divisaotribunalData.tribunal}
            setValue={addValorTribunal}
            label={'Tribunal'}
            />

<Input
type="text"
id="codigodiv"
label="CodigoDiv"
className="inputIncNome"
name="codigodiv"
value={divisaotribunalData.codigodiv}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={divisaotribunalData.endereco}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={divisaotribunalData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={divisaotribunalData.fax}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={divisaotribunalData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="Obs"
className="inputIncNome"
name="obs"
value={divisaotribunalData.obs}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={divisaotribunalData.email}
onChange={onChange}               
/>

<Input
type="text"
id="andar"
label="Andar"
className="inputIncNome"
name="andar"
value={divisaotribunalData.andar}
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
 