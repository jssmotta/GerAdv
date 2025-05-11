// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IViaRecebimento } from "../../Interfaces/interface.ViaRecebimento";
import { ViaRecebimentoService } from "../../Services/ViaRecebimento.service";
import { ViaRecebimentoApi } from "../../Apis/ApiViaRecebimento";
import ViaRecebimentoWindow from "./ViaRecebimentoWindow";

interface ViaRecebimentoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ViaRecebimentoWindowId: React.FC<ViaRecebimentoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const viarecebimentoService = useMemo(() => {
        return new ViaRecebimentoService(
            new ViaRecebimentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IViaRecebimento | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await viarecebimentoService.fetchViaRecebimentoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ViaRecebimentoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedViaRecebimento={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ViaRecebimentoWindowId;