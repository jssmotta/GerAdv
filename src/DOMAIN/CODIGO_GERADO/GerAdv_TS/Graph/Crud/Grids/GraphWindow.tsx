import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import GraphInc from "../Inc/Graph";
import { IGraph } from "../../Interfaces/interface.Graph";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GraphEmpty } from "@/app/GerAdv_TS/Models/Graph";
import { useWindow } from "@/app/hooks/useWindows";

interface GraphWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGraph?: IGraph;
    onSuccess: () => void;
    onError: () => void;
}

const GraphWindow: React.FC<GraphWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGraph,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/graph/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGraph?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedGraph]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGraph?.id ?? 0).toString()}
                >
                    <GraphInc
                        id={selectedGraph?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGraph: React.FC<GraphWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GraphWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGraph={GraphEmpty()}>
        </GraphWindow>
    )
};

export default GraphWindow;