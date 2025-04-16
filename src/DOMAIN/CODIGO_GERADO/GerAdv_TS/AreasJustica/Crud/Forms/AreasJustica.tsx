"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAreasJustica } from '../../Interfaces/interface.AreasJustica';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';

interface AreasJusticaFormProps {
    areasjusticaData: IAreasJustica;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AreasJusticaForm: React.FC<AreasJusticaFormProps> = ({
    areasjusticaData,
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
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (areasjusticaData.id === 0) {
    areasjusticaData.area = getParamFromUrl("area");
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

  if (areasjusticaData.id === 0) {
    areasjusticaData.justica = getParamFromUrl("justica");
  }
}
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        areasjusticaData.area = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        areasjusticaData.justica = e.id;
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

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <AreaComboBox
            name={'area'}
            value={areasjusticaData.area}
            setValue={addValorArea}
            label={'Area'}
            />

            <JusticaComboBox
            name={'justica'}
            value={areasjusticaData.justica}
            setValue={addValorJustica}
            label={'Justica'}
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
 