// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IOutrasPartesCliente } from "../../Interfaces/interface.OutrasPartesCliente";
import { OutrasPartesClienteService } from "../../Services/OutrasPartesCliente.service";
import { OutrasPartesClienteApi } from "../../Apis/ApiOutrasPartesCliente";
import OutrasPartesClienteWindow from "./OutrasPartesClienteWindow";

interface OutrasPartesClienteWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const OutrasPartesClienteWindowId: React.FC<OutrasPartesClienteWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const outraspartesclienteService = useMemo(() => {
        return new OutrasPartesClienteService(
            new OutrasPartesClienteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IOutrasPartesCliente | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await outraspartesclienteService.fetchOutrasPartesClienteById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <OutrasPartesClienteWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedOutrasPartesCliente={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default OutrasPartesClienteWindowId;