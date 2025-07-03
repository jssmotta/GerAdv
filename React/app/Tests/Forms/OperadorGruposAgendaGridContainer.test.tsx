// OperadorGruposAgendaGridContainer.test.tsx
import React from 'react';
import { render, screen } from '@testing-library/react';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import OperadorGruposAgendaGridContainer from '@/app/GerAdv_TS/OperadorGruposAgenda/Components/OperadorGruposAgendaGridContainer';
describe('OperadorGruposAgendaGridContainer', () => {
  it('renders the grid component output', () => {
    // Mock grid with a render method
    const mockGrid: IGridComponent = {
      render: () => <div data-testid='mock-grid'>Mock Grid Content</div>
    };
    render(<OperadorGruposAgendaGridContainer grid={mockGrid} />);
    // Assert the mock grid content is rendered
    expect(screen.getByTestId('mock-grid')).toHaveTextContent('Mock Grid Content');
  });
});