"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ITribunal } from '../../Interfaces/interface.Tribunal';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';

interface TribunalFormProps {
    tribunalData: ITribunal;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TribunalForm: React.FC<TribunalFormProps> = ({
    tribunalData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeInstancia, setNomeInstancia] = useState('');
            const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribunalData.id === 0) {
    tribunalData.area = getParamFromUrl("area");
  }
}
 
if (getParamFromUrl("justica") > 0) {
  justicaApi
    .getById(getParamFromUrl("justica"))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribunalData.id === 0) {
    tribunalData.justica = getParamFromUrl("justica");
  }
}
 
if (getParamFromUrl("instancia") > 0) {
  instanciaApi
    .getById(getParamFromUrl("instancia"))
    .then((response) => {
      setNomeInstancia(response.data.nroprocesso);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribunalData.id === 0) {
    tribunalData.instancia = getParamFromUrl("instancia");
  }
}
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        tribunalData.area = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        tribunalData.justica = e.id;
                      };
 const addValorInstancia = (e: any) => {
                        if (e?.id>0)
                        tribunalData.instancia = e.id;
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
  {nomeArea && (<h2>{nomeArea}</h2>)}
{nomeJustica && (<h2>{nomeJustica}</h2>)}
{nomeInstancia && (<h2>{nomeInstancia}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={tribunalData.nome}
            onChange={onChange}
            required
          />

            <AreaComboBox
            name={'area'}
            value={tribunalData.area}
            setValue={addValorArea}
            label={'Area'}
            />

            <JusticaComboBox
            name={'justica'}
            value={tribunalData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

<Input
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={tribunalData.descricao}
onChange={onChange}               
/>

            <InstanciaComboBox
            name={'instancia'}
            value={tribunalData.instancia}
            setValue={addValorInstancia}
            label={'Instancia'}
            />

<Input
type="text"
id="sigla"
label="Sigla"
className="inputIncNome"
name="sigla"
value={tribunalData.sigla}
onChange={onChange}               
/>

<Input
type="text"
id="web"
label="Web"
className="inputIncNome"
name="web"
value={tribunalData.web}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/divisaotribunal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tribunal=${tribunalData.id}`)}>Divisao Tribunal</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/poderjudiciarioassociado${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tribunal=${tribunalData.id}`)}>Poder Judiciario Associado</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/tribenderecos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?tribunal=${tribunalData.id}`)}>Trib Endereços</div>

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
 