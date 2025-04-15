//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GruposEmpresasEmpty } from "../../../Models/GruposEmpresas";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import GruposEmpresasInc from "../Inc/GruposEmpresas";
import { IGruposEmpresas } from "../../Interfaces/interface.GruposEmpresas";
import { GruposEmpresasService } from "../../Services/GruposEmpresas.service";
import { GruposEmpresasApi } from "../../Apis/ApiGruposEmpresas";
import { GruposEmpresasGridMobileComponent } from "../GridsMobile/GruposEmpresas";
import { GruposEmpresasGridDesktopComponent } from "../GridsDesktop/GruposEmpresas";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGruposEmpresas } from "../../Filters/GruposEmpresas";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import GruposEmpresasWindow from "./GruposEmpresasWindow";

const GruposEmpresasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gruposempresas, setGruposEmpresas] = useState<IGruposEmpresas[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGruposEmpresas, setSelectedGruposEmpresas] = useState<IGruposEmpresas>(GruposEmpresasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGruposEmpresas | undefined | null>(null);

    const gruposempresasService = useMemo(() => {
      return new GruposEmpresasService(
          new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGruposEmpresas = async (filtro?: FilterGruposEmpresas | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gruposempresasService.getList(filtro ?? {} as FilterGruposEmpresas);
        setGruposEmpresas(data);
      }
      else {
        const data = await gruposempresasService.getAll(filtro ?? {} as FilterGruposEmpresas);
        setGruposEmpresas(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGruposEmpresas(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gruposempresas: IGruposEmpresas) => {
      if (isMobile) {
        router.push(`/pages/gruposempresas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gruposempresas.id}`);
      } else {
        setSelectedGruposEmpresas(gruposempresas);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gruposempresas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGruposEmpresas(GruposEmpresasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGruposEmpresas(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gruposempresas = e.dataItem;		
        setDeleteId(gruposempresas.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGruposEmpresas(currFilter);
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
           <GruposEmpresasGridMobileComponent data={gruposempresas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <GruposEmpresasGridDesktopComponent data={gruposempresas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <GruposEmpresasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGruposEmpresas={selectedGruposEmpresas}>       
        </GruposEmpresasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GruposEmpresasGrid;