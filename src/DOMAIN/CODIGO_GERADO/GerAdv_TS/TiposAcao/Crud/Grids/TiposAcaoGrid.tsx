//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TiposAcaoEmpty } from "../../../Models/TiposAcao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TiposAcaoInc from "../Inc/TiposAcao";
import { ITiposAcao } from "../../Interfaces/interface.TiposAcao";
import { TiposAcaoService } from "../../Services/TiposAcao.service";
import { TiposAcaoApi } from "../../Apis/ApiTiposAcao";
import { TiposAcaoGridMobileComponent } from "../GridsMobile/TiposAcao";
import { TiposAcaoGridDesktopComponent } from "../GridsDesktop/TiposAcao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTiposAcao } from "../../Filters/TiposAcao";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TiposAcaoWindow from "./TiposAcaoWindow";

const TiposAcaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tiposacao, setTiposAcao] = useState<ITiposAcao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTiposAcao, setSelectedTiposAcao] = useState<ITiposAcao>(TiposAcaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TiposAcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTiposAcao | undefined | null>(null);

    const tiposacaoService = useMemo(() => {
      return new TiposAcaoService(
          new TiposAcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTiposAcao = async (filtro?: FilterTiposAcao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tiposacaoService.getList(filtro ?? {} as FilterTiposAcao);
        setTiposAcao(data);
      }
      else {
        const data = await tiposacaoService.getAll(filtro ?? {} as FilterTiposAcao);
        setTiposAcao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTiposAcao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tiposacao: ITiposAcao) => {
      if (isMobile) {
        router.push(`/pages/tiposacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tiposacao.id}`);
      } else {
        setSelectedTiposAcao(tiposacao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tiposacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTiposAcao(TiposAcaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTiposAcao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tiposacao = e.dataItem;		
        setDeleteId(tiposacao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTiposAcao(currFilter);
            } catch {
            // falta uma mensagem de erro
            } finally {
            setDeleteId(null);
                setIsModalOpen(false);
            }
        }
    };
      
    const cancelDelete = () => {
        setDeleteId(null);
        setIsModalOpen(false);
    };

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <TiposAcaoGridMobileComponent data={tiposacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TiposAcaoGridDesktopComponent data={tiposacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TiposAcaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTiposAcao={selectedTiposAcao}>       
        </TiposAcaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TiposAcaoGrid;