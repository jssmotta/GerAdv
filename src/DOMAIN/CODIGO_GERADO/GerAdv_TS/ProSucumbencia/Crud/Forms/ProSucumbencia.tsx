"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProSucumbencia } from '../../Interfaces/interface.ProSucumbencia';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import TipoOrigemSucumbenciaComboBox from '@/app/GerAdv_TS/TipoOrigemSucumbencia/ComboBox/TipoOrigemSucumbencia';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';
import { TipoOrigemSucumbenciaApi } from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Apis/ApiTipoOrigemSucumbencia';

interface ProSucumbenciaFormProps {
    prosucumbenciaData: IProSucumbencia;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProSucumbenciaForm: React.FC<ProSucumbenciaFormProps> = ({
    prosucumbenciaData,
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
const [nomeInstancia, setNomeInstancia] = useState('');
            const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoOrigemSucumbencia, setNomeTipoOrigemSucumbencia] = useState('');
            const tipoorigemsucumbenciaApi = new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prosucumbenciaData.id === 0) {
    prosucumbenciaData.processo = getParamFromUrl("processos");
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

  if (prosucumbenciaData.id === 0) {
    prosucumbenciaData.instancia = getParamFromUrl("instancia");
  }
}
 
if (getParamFromUrl("tipoorigemsucumbencia") > 0) {
  tipoorigemsucumbenciaApi
    .getById(getParamFromUrl("tipoorigemsucumbencia"))
    .then((response) => {
      setNomeTipoOrigemSucumbencia(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prosucumbenciaData.id === 0) {
    prosucumbenciaData.tipoorigemsucumbencia = getParamFromUrl("tipoorigemsucumbencia");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        prosucumbenciaData.processo = e.id;
                      };
 const addValorInstancia = (e: any) => {
                        if (e?.id>0)
                        prosucumbenciaData.instancia = e.id;
                      };
 const addValorTipoOrigemSucumbencia = (e: any) => {
                        if (e?.id>0)
                        prosucumbenciaData.tipoorigemsucumbencia = e.id;
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
  {nomeProcessos && (<h2>{nomeProcessos}</h2>)}
{nomeInstancia && (<h2>{nomeInstancia}</h2>)}
{nomeTipoOrigemSucumbencia && (<h2>{nomeTipoOrigemSucumbencia}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={prosucumbenciaData.nome}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={prosucumbenciaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <InstanciaComboBox
            name={'instancia'}
            value={prosucumbenciaData.instancia}
            setValue={addValorInstancia}
            label={'Instancia'}
            />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={prosucumbenciaData.data}
onChange={onChange}               
/>

            <TipoOrigemSucumbenciaComboBox
            name={'tipoorigemsucumbencia'}
            value={prosucumbenciaData.tipoorigemsucumbencia}
            setValue={addValorTipoOrigemSucumbencia}
            label={'Tipo Origem Sucumbencia'}
            />

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={prosucumbenciaData.valor}
onChange={onChange}               
/>

<Input
type="text"
id="percentual"
label="Percentual"
className="inputIncNome"
name="percentual"
value={prosucumbenciaData.percentual}
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
 