//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EscritoriosEmpty } from "../../../Models/Escritorios";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import EscritoriosInc from "../Inc/Escritorios";
import { IEscritorios } from "../../Interfaces/interface.Escritorios";
import { EscritoriosService } from "../../Services/Escritorios.service";
import { EscritoriosApi } from "../../Apis/ApiEscritorios";
import { EscritoriosGridMobileComponent } from "../GridsMobile/Escritorios";
import { EscritoriosGridDesktopComponent } from "../GridsDesktop/Escritorios";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEscritorios } from "../../Filters/Escritorios";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import EscritoriosWindow from "./EscritoriosWindow";

const EscritoriosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [escritorios, setEscritorios] = useState<IEscritorios[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEscritorios, setSelectedEscritorios] = useState<IEscritorios>(EscritoriosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEscritorios | undefined | null>(null);

    const escritoriosService = useMemo(() => {
      return new EscritoriosService(
          new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEscritorios = async (filtro?: FilterEscritorios | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await escritoriosService.getList(filtro ?? {} as FilterEscritorios);
        setEscritorios(data);
      }
      else {
        const data = await escritoriosService.getAll(filtro ?? {} as FilterEscritorios);
        setEscritorios(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEscritorios(currFilter);
    }, [showInc]);
  
    const handleRowClick = (escritorios: IEscritorios) => {
      if (isMobile) {
        router.push(`/pages/escritorios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${escritorios.id}`);
      } else {
        setSelectedEscritorios(escritorios);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/escritorios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEscritorios(EscritoriosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEscritorios(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const escritorios = e.dataItem;		
        setDeleteId(escritorios.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEscritorios(currFilter);
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
           <EscritoriosGridMobileComponent data={escritorios} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <EscritoriosGridDesktopComponent data={escritorios} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <EscritoriosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEscritorios={selectedEscritorios}>       
        </EscritoriosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EscritoriosGrid;