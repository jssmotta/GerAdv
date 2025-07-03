// EMPClassRiscosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { EMPClassRiscosGridAdapter } from '@/app/GerAdv_TS/EMPClassRiscos/Adapter/EMPClassRiscosGridAdapter';
// Mock EMPClassRiscosGrid component
jest.mock('@/app/GerAdv_TS/EMPClassRiscos/Crud/Grids/EMPClassRiscosGrid', () => () => <div data-testid='empclassriscos-grid-mock' />);
describe('EMPClassRiscosGridAdapter', () => {
  it('should render EMPClassRiscosGrid component', () => {
    const adapter = new EMPClassRiscosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('empclassriscos-grid-mock')).toBeInTheDocument();
  });
});