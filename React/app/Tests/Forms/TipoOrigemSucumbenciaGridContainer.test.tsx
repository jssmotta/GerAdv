// TipoOrigemSucumbenciaGridContainer.test.tsx
import React from 'react';
import { render, screen } from '@testing-library/react';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TipoOrigemSucumbenciaGridContainer from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Components/TipoOrigemSucumbenciaGridContainer';
describe('TipoOrigemSucumbenciaGridContainer', () => {
  it('renders the grid component output', () => {
    // Mock grid with a render method
    const mockGrid: IGridComponent = {
      render: () => <div data-testid='mock-grid'>Mock Grid Content</div>
    };
    render(<TipoOrigemSucumbenciaGridContainer grid={mockGrid} />);
    // Assert the mock grid content is rendered
    expect(screen.getByTestId('mock-grid')).toHaveTextContent('Mock Grid Content');
  });
});